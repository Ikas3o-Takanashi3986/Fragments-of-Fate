using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FadeInSceneStart : MonoBehaviour
{
    public Image panelNegro;
    public float duracionFade = 2f;

    void Start()
    {
        panelNegro.raycastTarget = false;


        Color color = panelNegro.color;
        color.a = 1f;
        panelNegro.color = color;

        StartCoroutine(FadeOutYVolver());
    }

    IEnumerator FadeOutYVolver()
    {

        float tiempo = 0f;
        while (tiempo < duracionFade)
        {
            tiempo += Time.deltaTime;
            float alpha = Mathf.Lerp(1f, 0f, tiempo / duracionFade);
            panelNegro.color = new Color(0, 0, 0, alpha);
            yield return null;
        }


        yield return new WaitForSeconds(2f);


        tiempo = 0f;
        while (tiempo < duracionFade)
        {
            tiempo += Time.deltaTime;
            float alpha = Mathf.Lerp(0f, 1f, tiempo / duracionFade);
            panelNegro.color = new Color(0, 0, 0, alpha);
            yield return null;
        }


        StartCoroutine(FadeOutYVolver());
    }
}
