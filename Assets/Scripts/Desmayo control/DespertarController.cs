using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DespertarController : MonoBehaviour
{
    public Image pantallaNegra;              
    public Transform jugador;                
    public Transform puntoDeReaparicion;    
    public GameObject canvasDespertar;      

    public int cantidadParpadeos = 3;
    public float duracionParpadeo = 0.4f;
    public float intervaloEntreParpadeos = 0.3f;

    void Start()
    {
        
        if (canvasDespertar != null)
            canvasDespertar.SetActive(false);
    }

    public void IniciarDespertar()
    {
        if (canvasDespertar != null)
            canvasDespertar.SetActive(true);

        
        pantallaNegra.color = new Color(0, 0, 0, 1);

        StartCoroutine(SecuenciaDespertar());
    }

    IEnumerator SecuenciaDespertar()
    {
        yield return new WaitForSeconds(3f);

       
        if (jugador != null && puntoDeReaparicion != null)
        {
            jugador.position = puntoDeReaparicion.position;
            jugador.rotation = puntoDeReaparicion.rotation;
        }

       
        yield return StartCoroutine(Fade(1f, 0f, duracionParpadeo));

        
        for (int i = 0; i < cantidadParpadeos; i++)
        {
            yield return new WaitForSeconds(intervaloEntreParpadeos);

            yield return StartCoroutine(Fade(0f, 1f, duracionParpadeo)); 
            yield return new WaitForSeconds(intervaloEntreParpadeos);
            yield return StartCoroutine(Fade(1f, 0f, duracionParpadeo)); 
        }

       
        yield return StartCoroutine(Fade(1f, 0f, 1.5f));

       
        if (canvasDespertar != null)
            canvasDespertar.SetActive(false);
    }

    IEnumerator Fade(float fromAlpha, float toAlpha, float duracion)
    {
        float tiempo = 0f;

        while (tiempo < duracion)
        {
            tiempo += Time.deltaTime;
            float alpha = Mathf.Lerp(fromAlpha, toAlpha, tiempo / duracion);
            pantallaNegra.color = new Color(0, 0, 0, alpha);
            yield return null;
        }
        pantallaNegra.color = new Color(0, 0, 0, toAlpha);
    }
}
