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
        panelNegro.gameObject.SetActive(true);

        Color color = panelNegro.color;
        color.a = 1f;
        panelNegro.color = color;

        StartCoroutine(FadeOut());
    }

    IEnumerator FadeOut()
    {
        float tiempo = 0f;
        Color colorOriginal = panelNegro.color;

        while (tiempo < duracionFade)
        {
            tiempo += Time.deltaTime;
            float alpha = 1f - Mathf.Clamp01(tiempo / duracionFade);
            panelNegro.color = new Color(colorOriginal.r, colorOriginal.g, colorOriginal.b, alpha);
            yield return null;
        }

        panelNegro.gameObject.SetActive(false);
    }
}
