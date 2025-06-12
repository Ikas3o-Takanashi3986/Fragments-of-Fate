using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ExplosionEventCaller : MonoBehaviour
{
    public GameObject explosionPrefab;
    public Transform explosionSpawnPoint;

    //DESMAYO SONIDO

    public AudioSource audioSource;
    public AudioClip sonidoGolpe;
    public AudioClip sonidoArrastre;
    private AudioSource audioLoopSource;

    //EXPLOSION SONIDO

    public AudioClip sonidoMalestar;
    public AudioClip sonidoGolpeSuelo;
    public AudioClip sonidoExplosion;
    public AudioClip musicaDeFondo;

    private float volumenSonidoFondoObjetivo = 0.5f;

    //CAMBIO ESCENA

    public string nombreEscenaFinal = "EscenaFinal";

    //SUBTITULOS DESMAYO

    public SubtitulosController subtitulosController;
    private Coroutine rutinaSubtitulos;

    private void Awake()
    {
        
        GameObject fuenteLoop = new GameObject("AudioLoopSource");
        fuenteLoop.transform.parent = this.transform;
        audioLoopSource = fuenteLoop.AddComponent<AudioSource>();
        audioLoopSource.loop = true;
    }
    public void ActivarExplosion()
    {
        if (explosionPrefab != null && explosionSpawnPoint != null)
        {
            Instantiate(explosionPrefab, explosionSpawnPoint.position, Quaternion.identity);
            Debug.Log("Explosión activada desde Animation Event");
        }
        else
        {
            Debug.LogWarning("Faltan explosionPrefab o explosionSpawnPoint asignados.");
        }
        if (sonidoExplosion != null)
            audioSource.PlayOneShot(sonidoExplosion);
    }

    public void ReproducirSonidoMalestar() 
    {
        if (audioSource && sonidoMalestar)
            audioSource.PlayOneShot(sonidoMalestar);
    }
    public void SonidoGolpe()
    {
        if (sonidoGolpe != null)
            audioSource.PlayOneShot(sonidoGolpe);


    }

    public void ReproducirSonidoFondo()
    {
        StartCoroutine(FadeInSonidoFondo());
    }


    public void DetenerSonidoFondo()
    {
        StartCoroutine(FadeOutSonidoFondo()); // ahora funciona sin error
    }

    public void CambiarEscena()
    {
        StartCoroutine(FadeOutSonidoFondo(nombreEscenaFinal));
    }

    IEnumerator PlaySoundClip(AudioClip clip)
    {
        if (clip == null)
            yield break;

        audioSource.loop = false;
        audioSource.clip = clip;
        audioSource.volume = 1f;
        audioSource.Play();

        yield return new WaitForSeconds(clip.length);
    }

    IEnumerator FadeInSonidoFondo()
    {
        if (musicaDeFondo == null)
            yield break;

        audioLoopSource.clip = musicaDeFondo;
        audioLoopSource.loop = true;
        audioLoopSource.volume = 0f;
        audioLoopSource.Play();

        float duracion = 2f; 
        float tiempo = 0f;

        while (tiempo < duracion)
        {
            tiempo += Time.deltaTime;
            audioLoopSource.volume = Mathf.Lerp(0f, volumenSonidoFondoObjetivo, tiempo / duracion);
            yield return null;
        }

        audioLoopSource.volume = volumenSonidoFondoObjetivo;
    }

    IEnumerator FadeOutSonidoFondo()
    {
        yield return StartCoroutine(FadeOutSonidoFondo(nombreEscenaFinal));
    }

    IEnumerator FadeOutSonidoFondo(string escena)
    {
        float duracion = 2f;
        float tiempo = 0f;
        float volumenInicial = audioLoopSource.volume;

        while (tiempo < duracion)
        {
            tiempo += Time.deltaTime;
            audioLoopSource.volume = Mathf.Lerp(volumenInicial, 0f, tiempo / duracion);
            yield return null;
        }

        audioLoopSource.Stop();
        audioLoopSource.volume = volumenSonidoFondoObjetivo;

        SceneManager.LoadScene(escena);
    }

    //SONIDO ANIMACION CONFIG

    public void ReproducirSonidoGolpe()
    {
        audioSource.PlayOneShot(sonidoGolpe);
    }

    public void ReproducirSonidoArrastree()
    {
        if (sonidoArrastre != null && audioLoopSource != null)
        {
            audioLoopSource.clip = sonidoArrastre;
            audioLoopSource.Play();
        }
    }

    public void DetenerSonidoArrastre()
    {
        if (audioLoopSource != null)
        {
            audioLoopSource.Stop();
        }
    }

    //SUBTITULOS CONFIG

    public void IniciarSubtitulos()
    {
        if (subtitulosController != null)
            rutinaSubtitulos = StartCoroutine(subtitulosController.MostrarSubtitulos());
    }

    public void DetenerSubtitulos()
    {
        if (subtitulosController != null)
            subtitulosController.OcultarSubtitulos();
    }
}
