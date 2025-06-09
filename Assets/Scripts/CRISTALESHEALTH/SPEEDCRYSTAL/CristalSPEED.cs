using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CristalSPEED : MonoBehaviour
{
    public float aumentoVelocidad = 2f;
    public float duracionEfecto = 25f;
    public AudioSource sonidoRecogida;

    public float alturaFlotacion = 0.5f;
    public float velocidadFlotacion = 2f;

    private Vector3 posicionInicial;

    void Start()
    {
        posicionInicial = transform.position;
    }

    void Update()
    {

        float desplazamiento = Mathf.Sin(Time.time * velocidadFlotacion) * alturaFlotacion;
        transform.position = new Vector3(
            posicionInicial.x,
            posicionInicial.y + desplazamiento,
            posicionInicial.z
        );
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            FPSPersonajePrincipalController jugador = other.GetComponent<FPSPersonajePrincipalController>();

            if (jugador != null)
            {
                jugador.StartCoroutine(AumentarVelocidadTemporal(jugador, aumentoVelocidad, duracionEfecto));
            }

            if (sonidoRecogida != null)
            {
                sonidoRecogida.Play();
            }

            Destroy(gameObject);
        }
    }

    public static System.Collections.IEnumerator AumentarVelocidadTemporal(FPSPersonajePrincipalController jugador, float incremento, float duracion)
    {
        float velocidadBase = jugador.velocidad;
        float correrBase = jugador.velocidadCorrer;

        jugador.velocidad += incremento;
        jugador.velocidadCorrer += incremento;

        float tiempo = 0f;
        while (tiempo < duracion)
        {
            if (jugador == null) yield break;
            tiempo += Time.deltaTime;
            yield return null;
        }

        if (jugador != null)
        {
            jugador.velocidad = velocidadBase;
            jugador.velocidadCorrer = correrBase;
        }
    }
}

