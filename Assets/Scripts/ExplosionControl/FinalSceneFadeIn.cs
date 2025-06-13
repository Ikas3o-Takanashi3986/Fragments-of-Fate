using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinalSceneFadeIn : MonoBehaviour
{
    public CanvasGroup panelNegro;

    void Start()
    {
        panelNegro.alpha = 1f; 
        StartCoroutine(FadeIn(1.5f));  
    }

    IEnumerator FadeIn(float duracion)
    {
        float tiempo = 0f;
        while (tiempo < duracion)
        {
            tiempo += Time.deltaTime;
            panelNegro.alpha = Mathf.Lerp(1f, 0f, tiempo / duracion);
            yield return null;
        }

        panelNegro.alpha = 0f;
    }
}
