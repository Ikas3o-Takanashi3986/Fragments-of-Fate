using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RecolectarLlaves : MonoBehaviour
{
    private bool jugadorCerca = false;
    private float tiempoPresionando = 0f;
    private float tiempoRequerido = 5f;

    private void Update()
    {
        if (jugadorCerca)
        {
            if (Input.GetKey(KeyCode.E))
            {
                tiempoPresionando += Time.deltaTime;
                Debug.Log("Tiempo presionando E: " + tiempoPresionando);

                if (tiempoPresionando >= tiempoRequerido)
                {
                    RecolectarLlave();
                }
            }
            else
            {
                if (tiempoPresionando > 0)
                {
                    Debug.Log("Se interrumpió el tiempo para recolectar.");
                }
                tiempoPresionando = 0f;
            }
        }
    }

    private void RecolectarLlave()
    {
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        PlayerController playerController = player.GetComponent<PlayerController>();
        if (playerController != null)
        {
            if (gameObject.CompareTag("LlaveR"))
            {
                playerController.RecolectarLlaveR();
            }
            else if (gameObject.CompareTag("LlaveA"))
            {
                playerController.RecolectarLlaveA();
            }
        }

        Destroy(gameObject);
        Debug.Log("Llave recolectada con éxito.");
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            jugadorCerca = true;
            Debug.Log("Mantén presionada 'E' por 5 segundos para recoger la llave.");
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            jugadorCerca = false;
            tiempoPresionando = 0f;
            Debug.Log("Te alejaste de la llave.");
        }
    }
}
