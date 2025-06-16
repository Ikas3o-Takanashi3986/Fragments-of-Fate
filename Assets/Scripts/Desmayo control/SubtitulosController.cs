using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class SubtitulosController : MonoBehaviour
{
    public TMP_Text textoSubtitulo; 
    public string[] subtitulos;
    public float duracionPorSubtitulo = 5f;

    private int indiceActual = 0;
    private Coroutine rutinaSubtitulos;

    
    public void IniciarSubtitulos()
    {
        if (rutinaSubtitulos != null)
            StopCoroutine(rutinaSubtitulos);

        indiceActual = 0;
        rutinaSubtitulos = StartCoroutine(MostrarSubtitulos());
        textoSubtitulo.gameObject.SetActive(true);
    }

    
    public void OcultarSubtitulos()
    {
        if (rutinaSubtitulos != null)
            StopCoroutine(rutinaSubtitulos);

        textoSubtitulo.gameObject.SetActive(false);
    }

    public IEnumerator MostrarSubtitulos()
    {
        textoSubtitulo.gameObject.SetActive(true);
        while (true)
            while (indiceActual < subtitulos.Length)
            {
                textoSubtitulo.text = subtitulos[indiceActual];
                Debug.Log("Mostrando subtítulo: " + subtitulos[indiceActual]);
                indiceActual++;
                yield return new WaitForSeconds(duracionPorSubtitulo);
            }
        textoSubtitulo.gameObject.SetActive(false);
    }
}
