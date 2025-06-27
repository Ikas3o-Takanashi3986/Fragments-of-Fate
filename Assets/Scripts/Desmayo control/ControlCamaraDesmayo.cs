using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ControlCamaraDesmayo : MonoBehaviour
{
    public Camera camaraPrincipal;
    public Camera camaraDesmayo;
    public Image pantallaNegra;

    public float duracionFade = 1.5f;
    public float tiempoParpadeo = 0.4f;
    public int cantidadParpadeos = 3;

    public float tiempoNegroPostDesmayo = 20f; 

   
    
    public GameObject jugador;
    
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
        
        camaraDesmayo.transform.SetPositionAndRotation(
            camaraPrincipal.transform.position,
            camaraPrincipal.transform.rotation
        );
        camaraDesmayo.transform.parent = null;

        
        if (jugador != null)
            jugador.SetActive(false);

        StartCoroutine(SecuenciaDesmayo());
    }

    IEnumerator SecuenciaDesmayo()
    {
        camaraPrincipal.gameObject.SetActive(false);
        camaraDesmayo.gameObject.SetActive(true);

        pantallaNegra.gameObject.SetActive(true);
        pantallaNegra.color = new Color(0, 0, 0, 0);

        if (animador != null)
            animador.Play("DesmayoTotal");

        while (!inicioParpadeoDesmayo)
            yield return null;

        yield return StartCoroutine(ParpadeoPantalla());

        pantallaNegra.color = new Color(0, 0, 0, 1);

        yield return new WaitForSeconds(tiempoNegroPostDesmayo);

        SceneManager.LoadScene("Persecusion despuesdesmayo");

    }

    public void ComenzarParpadeo()
    {
        inicioParpadeoDesmayo = true;
    }

    IEnumerator ParpadeoPantalla()
    {
        for (int i = 0; i < cantidadParpadeos; i++)
        {
            yield return StartCoroutine(FadePantalla(false));
            yield return new WaitForSeconds(tiempoParpadeo);
            yield return StartCoroutine(FadePantalla(true));
            yield return new WaitForSeconds(tiempoParpadeo);
        }

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

    public void RestaurarCamaraPrincipal()
    {
        camaraPrincipal.gameObject.SetActive(true);
        camaraDesmayo.gameObject.SetActive(false);
    }
}
