using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LinternaCristalControl : MonoBehaviour
{
    public Light linterna;
    public Light linterna2;
    public AudioSource audioSourceLIGHT;
    public AudioClip linternaClip;

    private int puntosActivados = 0;
    private int totalPuntos = 5;
    private bool linternaDesbloqueada = false;
    private bool linternaEncendida = false;

    void Update()
    {
        if (linternaDesbloqueada && Input.GetKeyDown(KeyCode.F))
        {
            linternaEncendida = !linternaEncendida;
            linterna.enabled = linternaEncendida;

            linterna2.enabled = linternaEncendida;

            if (audioSourceLIGHT != null && linternaClip != null)
            {
                audioSourceLIGHT.PlayOneShot(linternaClip);
            }
        }
    }


    public void RegistrarPuntoActivado()
    {
        puntosActivados++;
        Debug.Log("Punto activado: " + puntosActivados);

        if (puntosActivados >= totalPuntos)
        {
            linternaDesbloqueada = true;
            Debug.Log("¡Linterna desbloqueada! Presiona F para usarla.");
        }
    }
}
