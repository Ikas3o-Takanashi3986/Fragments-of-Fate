using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LatidosProximidad : MonoBehaviour
{
    public Transform jugador;

    public AudioSource audioLatido;
    public AudioClip latidoClip;

    public AudioSource audioZombie;
    public AudioClip zombieClip;

    public float distanciaMaxima = 30f;
    public float distanciaMinima = 5f;

    public float intervaloMinimo = 0.3f;
    public float intervaloMaximo = 1.5f;

    public float distanciaZombie = 15f;

    private float tiempoLatido = 0f;
    private float tiempoZombie = 0f;

    void Update()
    {
        if (jugador == null) return;

        float distancia = Vector3.Distance(transform.position, jugador.position);


        if (audioLatido != null && latidoClip != null && distancia <= distanciaMaxima)
        {
            float t = Mathf.InverseLerp(distanciaMaxima, distanciaMinima, distancia);
            float intervaloActual = Mathf.Lerp(intervaloMaximo, intervaloMinimo, t);

            tiempoLatido += Time.deltaTime;
            if (tiempoLatido >= intervaloActual)
            {
                audioLatido.PlayOneShot(latidoClip);
                tiempoLatido = 0f;
            }
        }
        else
        {
            tiempoLatido = 0f;
        }


        if (audioZombie != null && zombieClip != null)
        {
            if (distancia <= distanciaZombie)
            {

                if (!audioZombie.isPlaying)
                {
                    audioZombie.clip = zombieClip;
                    audioZombie.Play();
                }
            }
            else
            {
                if (audioZombie.isPlaying)
                {
                    audioZombie.Stop();
                }
            }
        }
    }
}