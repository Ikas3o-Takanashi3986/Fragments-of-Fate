using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PanelFadeIn : MonoBehaviour
{
    public Image panelNegro;
    public float duracionFade = 2f;
    public float tiempoAntesDeCargar = 1f;

    public void MostrarConFade()
    {
        gameObject.SetActive(true);
        StartCoroutine(FadeIn());
    }

    IEnumerator FadeIn()
    {
        float tiempo = 0f;
        Color colorOriginal = panelNegro.color;
        colorOriginal.a = 0f;
        panelNegro.color = colorOriginal;

        while (tiempo < duracionFade)
        {
            tiempo += Time.deltaTime;
            float alpha = Mathf.Clamp01(tiempo / duracionFade);
            panelNegro.color = new Color(colorOriginal.r, colorOriginal.g, colorOriginal.b, alpha);
            yield return null;
        }

        yield return new WaitForSeconds(tiempoAntesDeCargar);
        SceneManager.LoadScene(2);
    }
}
