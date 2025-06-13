using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DesmayoTrigger : MonoBehaviour
{
    public ControlCamaraDesmayo controlCamaraDesmayo;
    public GameObject enemigoPrefab;
    public Transform puntoDeSpawn;

  

    private bool yaDesmayo = false;

    private void OnTriggerEnter(Collider other)
    {
        if (!yaDesmayo && other.CompareTag("Player"))
        {
            yaDesmayo = true;

            Quaternion rotacion = Quaternion.Euler(0f, 0f, 0f);
            GameObject enemigo = Instantiate(enemigoPrefab, puntoDeSpawn.position, rotacion);

            // Activar animaci�n si existe
            Animator anim = enemigo.GetComponent<Animator>();
            if (anim != null)
            {
                anim.SetTrigger("Attack");
                Debug.Log("Animaci�n de ataque activada.");
            }
            else
            {
                Debug.LogWarning("No se encontr� Animator en el enemigo instanciado.");
            }

            // Inicia la secuencia de desmayo
            if (controlCamaraDesmayo != null)
                controlCamaraDesmayo.IniciarSecuenciaCompleta();

            // Destruye el enemigo despu�s de 5 segundos
            Destroy(enemigo, 5f);
        }
    }
}
