using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ParpadeoAlCargarEscena : MonoBehaviour
{
    public Image pantallaNegra;
    public int cantidadParpadeos = 3;
    public float duracionParpadeo = 0.4f;
    public float intervalo = 0.3f;

    void Start()
    {
        if (pantallaNegra != null)
        {
            pantallaNegra.color = new Color(0, 0, 0, 1); 
            StartCoroutine(Parpadeo());
        }
    }

    IEnumerator Parpadeo()
    {
        yield return new WaitForSeconds(2f); 

        for (int i = 0; i < cantidadParpadeos; i++)
        {
            yield return StartCoroutine(Fade(1f, 0f, duracionParpadeo)); 
            yield return new WaitForSeconds(intervalo);
            yield return StartCoroutine(Fade(0f, 1f, duracionParpadeo));
            yield return new WaitForSeconds(intervalo);
        }

        
        yield return StartCoroutine(Fade(1f, 0f, 1f));

        
        pantallaNegra.gameObject.SetActive(false);
    }

    IEnumerator Fade(float desde, float hasta, float duracion)
    {
        float tiempo = 0f;
        while (tiempo < duracion)
        {
            tiempo += Time.deltaTime;
            float alpha = Mathf.Lerp(desde, hasta, tiempo / duracion);
            pantallaNegra.color = new Color(0, 0, 0, alpha);
            yield return null;
        }
        pantallaNegra.color = new Color(0, 0, 0, hasta);
    }
}
