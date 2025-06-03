using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ControlCamaraDesmayo : MonoBehaviour
{
    public Camera camaraPrincipal;
    public Camera camaraDesmayo;
    public Image pantallaNegra;

    public float duracionFade = 1.5f;
    public float tiempoParpadeo = 0.4f;
    public int cantidadParpadeos = 3;

    public float tiempoNegroPostDesmayo = 20f; // Tiempo en negro tras parpadeos antes de cambiar cámara

    public DespertarController despertarController; // Referencia para activar parpadeo despertar

    private Animator animador;
    private bool inicioParpadeoDesmayo = false;

    private void Start()
    {
        camaraPrincipal.gameObject.SetActive(true);
        camaraDesmayo.gameObject.SetActive(false);

        if (pantallaNegra != null)
            pantallaNegra.gameObject.SetActive(false);

        if (camaraDesmayo != null)
            animador = camaraDesmayo.GetComponent<Animator>();
    }

    public void IniciarSecuenciaCompleta()
    {
        StartCoroutine(SecuenciaDesmayo());
    }

    IEnumerator SecuenciaDesmayo()
    {
        // Activar cámara desmayo, desactivar principal
        camaraPrincipal.gameObject.SetActive(false);
        camaraDesmayo.gameObject.SetActive(true);

        pantallaNegra.gameObject.SetActive(true);
        pantallaNegra.color = new Color(0, 0, 0, 0); // transparente al inicio

        // Reproducir animación desmayo (que en frame 261 ejecuta evento ComenzarParpadeo)
        if (animador != null)
            animador.Play("DesmayoTotal");

        // Esperar evento Animation Event para iniciar parpadeos
        while (!inicioParpadeoDesmayo)
            yield return null;

        // Ejecutar parpadeos de desmayo (fade in/out)
        yield return StartCoroutine(ParpadeoPantalla());

        // Pantalla queda completamente negra
        pantallaNegra.color = new Color(0, 0, 0, 1);

        // Tiempo en negro antes de cambiar cámara y teletransportar jugador
        yield return new WaitForSeconds(tiempoNegroPostDesmayo);

        // Cambiar a cámara principal
        camaraPrincipal.gameObject.SetActive(true);
        camaraDesmayo.gameObject.SetActive(false);

        // Mantener pantalla negra visible
        pantallaNegra.color = new Color(0, 0, 0, 1);
        pantallaNegra.gameObject.SetActive(true);

        // Iniciar parpadeo de despertar en cámara principal (despertarController)
        if (despertarController != null)
            despertarController.IniciarDespertar();
    }

    // Método llamado por Animation Event al frame 261
    public void ComenzarParpadeo()
    {
        inicioParpadeoDesmayo = true;
    }

    IEnumerator ParpadeoPantalla()
    {
        for (int i = 0; i < cantidadParpadeos; i++)
        {
            yield return StartCoroutine(FadePantalla(false)); // transparente
            yield return new WaitForSeconds(tiempoParpadeo);
            yield return StartCoroutine(FadePantalla(true));  // negro
            yield return new WaitForSeconds(tiempoParpadeo);
        }

        // Finaliza con pantalla negra
        yield return StartCoroutine(FadePantalla(true));
    }

    IEnumerator FadePantalla(bool aNegro)
    {
        float tiempo = 0f;
        float inicio = pantallaNegra.color.a;
        float fin = aNegro ? 1f : 0f;

        while (tiempo < duracionFade)
        {
            tiempo += Time.deltaTime;
            float alpha = Mathf.Lerp(inicio, fin, tiempo / duracionFade);
            pantallaNegra.color = new Color(0, 0, 0, alpha);
            yield return null;
        }
        pantallaNegra.color = new Color(0, 0, 0, fin);
    }

    // Método para restaurar cámara principal al final de despertar si quieres
    public void RestaurarCamaraPrincipal()
    {
        camaraPrincipal.gameObject.SetActive(true);
        camaraDesmayo.gameObject.SetActive(false);
    }
}
