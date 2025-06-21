using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class LuzParpadeoIntensidad : MonoBehaviour
{
    public float intensidadMinima = 0.2f;
    public float intensidadMaxima = 20f;
    public float velocidadParpadeo = 2f;
    public float duracionTotal = 30f;

    private Light luz;
    private Coroutine rutina;

    private void OnEnable()
    {
        luz = GetComponent<Light>();

        if (rutina == null)
            rutina = StartCoroutine(ParpadearIntensidad());
    }

    private IEnumerator ParpadearIntensidad()
    {
        float tiempo = 0f;
        float tiempoInterno = 0f;

        while (tiempo < duracionTotal)
        {

            float intensidad = Mathf.Lerp(
                intensidadMinima,
                intensidadMaxima,
                (Mathf.Sin(tiempoInterno * velocidadParpadeo) + 1f) / 2f
            );

            luz.intensity = intensidad;

            tiempo += Time.deltaTime;
            tiempoInterno += Time.deltaTime;

            yield return null;
        }

        luz.intensity = intensidadMinima;
        rutina = null;
    }
}