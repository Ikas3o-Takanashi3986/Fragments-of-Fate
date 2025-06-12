using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ActivarDesmayoConFinal : MonoBehaviour
{
    public GameObject mainCamera;
    public GameObject desmayoCamera;
    public Animator desmayoAnimator;


    public CanvasGroup panelNegro;     
    public GameObject panelFinal;

    public GameObject[] enemigos;

    public GameObject personaje;

    public Transform puntoDeInicio;

    private bool hasTriggered = false;

    private void OnTriggerEnter(Collider other)
    {
        if (!hasTriggered && other.CompareTag("Player"))
        {
            hasTriggered = true;

            
            mainCamera.SetActive(false);

            
            desmayoCamera.transform.position = puntoDeInicio.position;
            desmayoCamera.transform.rotation = puntoDeInicio.rotation;
            desmayoCamera.SetActive(true);

          
            panelNegro.alpha = 0f;

           
            panelFinal.SetActive(false);

            


           
            desmayoAnimator.Play("Desmayo", 0, 0f);
            desmayoAnimator.speed = 1f;   

          

            personaje.SetActive(false);
        }

        foreach (GameObject enemigo in enemigos)
        {
            if (enemigo != null)
                enemigo.SetActive(false);
        }

    }

   
    public void IniciarParpadeo()
    {
        StartCoroutine(SecuenciaParpadeo());
    }


    

    System.Collections.IEnumerator SecuenciaParpadeo()
    {
        yield return Parpadear(2, 0.3f);

        
        panelNegro.alpha = 0;
        yield return new WaitForSeconds(2f);

        
        yield return Parpadear(3, 0.5f);

        
        panelNegro.alpha = 1;
    }

    System.Collections.IEnumerator Parpadear(int veces, float duracion)
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
