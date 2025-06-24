using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivadorCueva : MonoBehaviour
{
    public SalirDeLaCueva[] enemigos;
    public float delayEntreEnemigos = 1.5f;

    private bool yaActivado = false;

    private void OnTriggerEnter(Collider other)
    {
        if (!yaActivado && other.CompareTag("Player"))
        {
            yaActivado = true;
            StartCoroutine(SacarEnemigosUnoPorUno());
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            foreach (SalirDeLaCueva enemigo in enemigos)
            {
                enemigo.Regresar();
            }

            yaActivado = false;
        }
    }

    IEnumerator SacarEnemigosUnoPorUno()
    {
        foreach (SalirDeLaCueva enemigo in enemigos)
        {
            enemigo.Salir();
            yield return new WaitForSeconds(delayEntreEnemigos);
        }
    }
}
