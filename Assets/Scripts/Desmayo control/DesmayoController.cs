using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DesmayoController : MonoBehaviour
{
    public Animator anim;                   
    public Image screenBlack;              
    public float delayBeforeBlink = 3f;    
    public int numberOfBlinks = 3;         
    public float blinkFadeDuration = 0.5f; 
    public float blinkInterval = 0.3f;     
    public string animationName = "DesmayoTotal"; 

    private bool hasFainted = false;

    public DespertarController despertarController; 

    public float tiempoEnNegro = 60f;  

    public GameObject canvasDesmayo;   

    void Start()
    {
        if (anim == null) anim = GetComponent<Animator>();
        screenBlack.color = new Color(0, 0, 0, 0); 

        if (canvasDesmayo != null)
            canvasDesmayo.SetActive(false); 
    }

    public void IniciarSecuenciaCompleta()
    {
        if (!hasFainted)
        {
            hasFainted = true;
            if (canvasDesmayo != null)
                canvasDesmayo.SetActive(true);

            anim.Play(animationName, 0); 
            StartCoroutine(SecuenciaDesmayo());
        }
    }

    IEnumerator SecuenciaDesmayo()
    {
        yield return new WaitForSeconds(6.5f);               
        yield return StartCoroutine(Fade(0f, 1f, 1f));      
        yield return new WaitForSeconds(delayBeforeBlink);   
        yield return StartCoroutine(BlinkEyes(numberOfBlinks, blinkFadeDuration, blinkInterval));
        yield return StartCoroutine(Fade(0f, 1f, 1f));       

        
        yield return new WaitForSeconds(tiempoEnNegro);

        
        if (canvasDesmayo != null)
            canvasDesmayo.SetActive(false);

        
        if (despertarController != null)
        {
            despertarController.IniciarDespertar();
        }
    }

    IEnumerator Fade(float from, float to, float duration)
    {
        float elapsed = 0f;
        Color color = screenBlack.color;
        while (elapsed < duration)
        {
            elapsed += Time.deltaTime;
            float alpha = Mathf.Lerp(from, to, elapsed / duration);
            screenBlack.color = new Color(color.r, color.g, color.b, alpha);
            yield return null;
        }
        screenBlack.color = new Color(color.r, color.g, color.b, to);
    }

    IEnumerator BlinkEyes(int count, float fadeDur, float interval)
    {
        for (int i = 0; i < count; i++)
        {
            yield return StartCoroutine(Fade(0f, 1f, fadeDur));
            yield return new WaitForSeconds(interval);
            yield return StartCoroutine(Fade(1f, 0f, fadeDur)); 
            yield return new WaitForSeconds(interval);
        }
    }
}
