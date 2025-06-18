using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArmaBob : MonoBehaviour
{
    public float velocidadCaminar = 5f;
    public float cantidadCaminarY = 0.03f;
    public float cantidadCaminarX = 0.015f;

    public float velocidadCorrer = 10f;
    public float cantidadCorrerY = 0.06f;
    public float cantidadCorrerX = 0.03f;

    public float fuerzaSalto = 0.1f;
    public float suavizadoSalto = 5f;

    private Vector3 posicionInicial;
    private float tiempo;
    private bool enElAire = false;
    private float offsetSalto = 0f;

    private CharacterController controlador;

    void Start()
    {
        posicionInicial = transform.localPosition;
        controlador = FindObjectOfType<CharacterController>();
    }

    void Update()
    {
        bool caminando = Input.GetAxis("Vertical") != 0 || Input.GetAxis("Horizontal") != 0;
        bool corriendo = caminando && Input.GetKey(KeyCode.LeftShift);

        float velocidad = caminando ? (corriendo ? velocidadCorrer : velocidadCaminar) : 0f;
        float cantidadY = corriendo ? cantidadCorrerY : cantidadCaminarY;
        float cantidadX = corriendo ? cantidadCorrerX : cantidadCaminarX;

        if (caminando)
        {
            tiempo += Time.deltaTime * velocidad;
            float offsetY = Mathf.Sin(tiempo) * cantidadY;
            float offsetX = Mathf.Cos(tiempo * 0.5f) * cantidadX;

            transform.localPosition = posicionInicial + new Vector3(offsetX, offsetY + offsetSalto, 0);
        }
        else
        {
            tiempo = 0;
            transform.localPosition = Vector3.Lerp(transform.localPosition, posicionInicial + new Vector3(0, offsetSalto, 0), Time.deltaTime * 5f);
        }


        if (controlador != null)
        {
            if (!controlador.isGrounded)
            {
                if (!enElAire)
                {
                    enElAire = true;
                    offsetSalto = -fuerzaSalto;
                }
            }
            else
            {
                enElAire = false;
                offsetSalto = Mathf.Lerp(offsetSalto, 0f, Time.deltaTime * suavizadoSalto);
            }
        }
    }
}
