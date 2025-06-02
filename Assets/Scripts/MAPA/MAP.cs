using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MAP : MonoBehaviour
{
    private bool jugadorCerca = false;
    private float tiempoPresionando = 0f;
    private float tiempoRequerido = 2f;
    private bool recolectado = false;

    public AudioSource audioSource;
    public AudioClip sonidoRecolectarMapa;

    void Update()
    {
        if (jugadorCerca)
        {
            if (Input.GetKey(KeyCode.E))
            {
                tiempoPresionando += Time.deltaTime;
                Debug.Log("Presionando E para recolectar: " + tiempoPresionando);

                if (tiempoPresionando >= tiempoRequerido && !recolectado)
                {
                    RecolectarPieza();
                }
            }
            else
            {
                if (tiempoPresionando > 0)
                {
                    Debug.Log("Recolección interrumpida.");
                }
                tiempoPresionando = 0f;
            }
        }
    }

    private void RecolectarPieza()
    {
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        PlayerController playerController = player.GetComponent<PlayerController>();

        if (playerController != null)
        {
            if (gameObject.CompareTag("Mapa1") && !playerController.mapa1Recolectado)
            {
                playerController.RecolectarMapa1();
                recolectado = true;
                Debug.Log("¡Pieza del Mapa 1 recolectada!");
            }
            else if (gameObject.CompareTag("Mapa2") && !playerController.mapa2Recolectado)
            {
                playerController.RecolectarMapa2();
                recolectado = true;
                Debug.Log("¡Pieza del Mapa 2 recolectada!");
            }

            if (recolectado)
            {
                if (audioSource != null && sonidoRecolectarMapa != null)
                {
                    audioSource.PlayOneShot(sonidoRecolectarMapa);
                }

                Destroy(gameObject);
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            jugadorCerca = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            jugadorCerca = false;
        }
    }

}