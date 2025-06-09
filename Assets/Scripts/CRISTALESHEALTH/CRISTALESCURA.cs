using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CRISTALESCURA : MonoBehaviour
{
    public float cantidadCuracion = 20f;
    public float altura = 0.5f;
    public float velocidad = 2f;

    public AudioSource audioRecogida;

    private Vector3 posicionInicial;
    private bool recogido = false;

    void Start()
    {
        posicionInicial = transform.position;
    }

    void Update()
    {
        float desplazamiento = Mathf.Sin(Time.time * velocidad) * altura;
        transform.position = new Vector3(
            posicionInicial.x,
            posicionInicial.y + desplazamiento,
            posicionInicial.z
        );
    }

    private void OnTriggerEnter(Collider other)
    {
        if (recogido) return;

        if (other.CompareTag("Player"))
        {
            recogido = true;

            StatsPlayer.vida = Mathf.Min(StatsPlayer.vida + cantidadCuracion, 100f);
            Debug.Log("Cristal Oscuro recogido. Vida actual: " + StatsPlayer.vida);


            if (audioRecogida != null)
            {
                audioRecogida.Play();
            }

            Destroy(gameObject);
        }
    }
}

