using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DespertarController : MonoBehaviour
{
    public Image pantallaNegra;              
    public Transform jugador;                
    public Transform puntoDeReaparicion;   
    public float delayAntesParpadeos = 3f;     

    public int cantidadParpadeos = 3;
    public float duracionParpadeo = 0.4f;
    public float intervaloEntreParpadeos = 0.3f;

    public ControlCamaraDesmayo controladorCamara;

    void Start()
    {
        if (pantallaNegra != null)
            pantallaNegra.gameObject.SetActive(false);
    }

    public void IniciarDespertar()
    {
        pantallaNegra.gameObject.SetActive(true);
        pantallaNegra.color = new Color(0, 0, 0, 1);
        StartCoroutine(SecuenciaDespertar());
    }

    IEnumerator SecuenciaDespertar()
    {
        yield return new WaitForSeconds(delayAntesParpadeos);

        CharacterController cc = jugador.GetComponent<CharacterController>();
        if (cc != null) cc.enabled = false;

        if (jugador != null && puntoDeReaparicion != null)
        {
            jugador.position = puntoDeReaparicion.position;
            jugador.rotation = puntoDeReaparicion.rotation;
        }

        
        yield return StartCoroutine(Fade(1f, 0f, duracionParpadeo));

        
        for (int i = 0; i < cantidadParpadeos; i++)
        {
            yield return new WaitForSeconds(intervaloEntreParpadeos);
            yield return StartCoroutine(Fade(0f, 1f, duracionParpadeo)); // cerrar ojos
            yield return new WaitForSeconds(intervaloEntreParpadeos);
            yield return StartCoroutine(Fade(1f, 0f, duracionParpadeo)); // abrir ojos
        }

        
        yield return StartCoroutine(Fade(1f, 0f, 1.5f));

        if (pantallaNegra != null)
            pantallaNegra.gameObject.SetActive(false);

        
        if (controladorCamara != null)
            controladorCamara.RestaurarCamaraPrincipal();
    }

    IEnumerator Fade(float fromAlpha, float toAlpha, float duracion)
    {
        float tiempo = 0f;

        while (tiempo < duracion)
        {
            tiempo += Time.deltaTime;
            float alpha = Mathf.Lerp(fromAlpha, toAlpha, tiempo / duracion);
            if (pantallaNegra != null)
                pantallaNegra.color = new Color(0, 0, 0, alpha);
            yield return null;
        }
        if (pantallaNegra != null)
            pantallaNegra.color = new Color(0, 0, 0, toAlpha);

        CharacterController cc = jugador.GetComponent<CharacterController>();
        if (cc != null) cc.enabled = true;
    }
}
