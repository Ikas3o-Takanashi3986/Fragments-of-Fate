using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ControlarParpadeo : MonoBehaviour
{
    public CanvasGroup panelNegro;
    public float duracionParpadeo = 0.3f;
    public float tiempoPantallaClara = 2f;
    public float tiempoPantallaNegraFinal = 8f; 

    public void IniciarParpadeo()
    {
        StartCoroutine(SecuenciaParpadeo());
    }

    IEnumerator SecuenciaParpadeo()
    {
        
        yield return Parpadear(2, duracionParpadeo);

        
        panelNegro.alpha = 0;
        yield return new WaitForSeconds(tiempoPantallaClara);

        yield return Parpadear(3, duracionParpadeo);

        
        panelNegro.alpha = 1;

       
    }

    IEnumerator Parpadear(int veces, float duracion)
    {
        for (int i = 0; i < veces; i++)
        {
            panelNegro.alpha = 1;
            yield return new WaitForSeconds(duracion);
            panelNegro.alpha = 0;
            yield return new WaitForSeconds(duracion);
        }
    }
}
