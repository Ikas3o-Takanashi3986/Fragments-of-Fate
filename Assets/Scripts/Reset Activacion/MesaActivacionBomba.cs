using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class MesaActivacionBomba : MonoBehaviour
{
    
    public GameObject mensaje1;                
    public GameObject mensaje2;               
    public TextMeshPro textoTemporizador;      

    
    public GameObject luzAlFinal;
    public GameObject luzAlFinal2;
    public GameObject luzAlFinal3;
    public GameObject luzAlFinal4;
    public GameObject luzAlFinal5;
    public float intervaloParpadeo = 0.5f;

    
    public GameObject conversacionUI;           
    public TextMeshProUGUI textoConversacion;   

    
    public ButtonLamp botonLampara;             

    
    public GameObject textoPresionarE;
    public GameObject pasoProhibido;

    private bool bombaActivada = false;
    private float tiempoRestante = 900f;       

    private bool jugadorDentro = false;

    public AudioSource sonidoAlarma;
    public AudioSource press;
    public AudioSource MUSICAESCAPE;

    void Update()
    {
        if (jugadorDentro && Input.GetKeyDown(KeyCode.E) && !bombaActivada)
        {
            pasoProhibido.SetActive(false);
            bombaActivada = true;
            ActivarEventos();

            press.Play();
            MUSICAESCAPE.Play();

            if (sonidoAlarma != null && !sonidoAlarma.isPlaying)
            {
                sonidoAlarma.Play();
                StartCoroutine(DetenerSonidoTrasTiempo(30f));
            }
        }

        if (bombaActivada)
        {
            tiempoRestante -= Time.deltaTime;

            int minutos = Mathf.FloorToInt(tiempoRestante / 60f);
            int segundos = Mathf.FloorToInt(tiempoRestante % 60f);
            textoTemporizador.text = string.Format("{0:00}:{1:00}", minutos, segundos);
        }
    }

    void ActivarEventos()
    {
        
        mensaje1.SetActive(true);
        mensaje2.SetActive(true);
        textoTemporizador.gameObject.SetActive(true);

        
        luzAlFinal.SetActive(true);
        luzAlFinal2.SetActive(true);
        luzAlFinal3.SetActive(true);
        luzAlFinal4.SetActive(true);
        luzAlFinal5.SetActive(true);

        StartCoroutine(ParpadearLuz());

        
        if (botonLampara != null)
            botonLampara.on = true;

        
        if (textoPresionarE != null)
            textoPresionarE.SetActive(false);

       
        StartCoroutine(MostrarConversacionTemporal());
    }

    IEnumerator ParpadearLuz()
    {
        while (true)
        {
            luzAlFinal.SetActive(!luzAlFinal.activeSelf);
            luzAlFinal2.SetActive(!luzAlFinal2.activeSelf);
            luzAlFinal3.SetActive(!luzAlFinal3.activeSelf);
            luzAlFinal4.SetActive(!luzAlFinal2.activeSelf);
            luzAlFinal5.SetActive(!luzAlFinal3.activeSelf);

            yield return new WaitForSeconds(intervaloParpadeo);
        }
    }

    IEnumerator MostrarConversacionTemporal()
    {
        yield return new WaitForSeconds(4f);

        if (textoConversacion != null)
            textoConversacion.text = "¡Necesito salir AHORA!";

        if (conversacionUI != null)
            conversacionUI.SetActive(true);

        yield return new WaitForSeconds(7f);

        if (conversacionUI != null)
            conversacionUI.SetActive(false);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            jugadorDentro = true;

            if (!bombaActivada && textoPresionarE != null)
                textoPresionarE.SetActive(true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            jugadorDentro = false;

            if (textoPresionarE != null)
                textoPresionarE.SetActive(false);
        }
    }

    IEnumerator DetenerSonidoTrasTiempo(float segundos)
    {
        yield return new WaitForSeconds(segundos);
        if (sonidoAlarma.isPlaying)
        {
            sonidoAlarma.Stop();
        }
    }

}
