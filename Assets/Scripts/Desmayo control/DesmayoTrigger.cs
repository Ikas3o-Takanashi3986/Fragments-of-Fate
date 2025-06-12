using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DesmayoTrigger : MonoBehaviour
{
    public ControlCamaraDesmayo controlCamaraDesmayo;
    public GameObject enemigoPrefab;
    public float distanciaDetras = 1.5f;
    public Vector3 ajusteAltura = new Vector3(0, 0.5f, 0);

    private bool yaDesmayo = false;

    private void OnTriggerEnter(Collider other)
    {
        if (!yaDesmayo && other.CompareTag("Player"))
        {
            yaDesmayo = true;

            Transform jugador = other.transform;
            Vector3 posicionDetras = jugador.position - jugador.forward * distanciaDetras + ajusteAltura;
            GameObject enemigo = Instantiate(enemigoPrefab, posicionDetras, Quaternion.LookRotation(jugador.position - posicionDetras));

            Animator anim = enemigo.GetComponent<Animator>();
            if (anim != null)
                anim.SetTrigger("Attack");

            controlCamaraDesmayo.IniciarSecuenciaCompleta();
        }
    }
}
