using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuntoLuz : MonoBehaviour
{
    public AudioSource audioSourcePunto;
    public AudioClip puntoClip;
    public LinternaCristalControl controlador;
    private bool fueActivado = false;
    private Light luz;

    void Start()
    {
        luz = GetComponent<Light>();
    }

    void OnMouseDown()
    {
        if (!fueActivado)
        {
            fueActivado = true;

            if (audioSourcePunto != null && puntoClip != null)
            {
                audioSourcePunto.PlayOneShot(puntoClip);
            }

            Renderer renderer = GetComponent<Renderer>();
            if (renderer != null)
            {
                renderer.material.color = Color.gray;
            }


            Collider col = GetComponent<Collider>();
            if (col != null)
            {
                col.enabled = false;
            }


            if (luz != null)
            {
                luz.enabled = false;
            }

            controlador.RegistrarPuntoActivado();
        }
    }
}