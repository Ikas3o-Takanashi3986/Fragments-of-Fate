using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EInteraction : MonoBehaviour
{
    private bool jugadorCerca = false;
    private float tiempoPresionando = 0f;
    private float tiempoRequerido = 0.5f;
    private bool cristalRecolectado = false;
    private bool LlaveDeAcceso1Recolectada = false;
    private bool LlaveDeAcceso2Recolectada = false;

    public GameObject ObjetivoM;

    public GameObject ObjetivoLLave1;
    public GameObject LlaveOne;

    public GameObject ObjetivoLLave2;

    public AudioSource audioSourceDoors;
    public AudioClip sonidoDOOR;

    public GameObject PuertaOne;
    public GameObject PuertaVisualOne;
    public GameObject PuertaVisualOnePT2;

    public GameObject PuertaTwo;
    public GameObject PuertaVisualTwo;
    public GameObject PuertaVisualTwoPT2;

    public DialogueTrigger dialogueTrigger;
    public DialogueTrigger dialogueTriggerl;

    public AudioSource audioSourceKey;
    public AudioClip sonidoLlave;

    public AudioSource audioSourceCRISTAL;
    public AudioClip sonidoCRISTAL;

    public GameObject M3Trigger;
    public GameObject M3RedRoom;
    public GameObject M2;

    public bool CristalRecolectado
    {
        get { return cristalRecolectado; }
    }

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (jugadorCerca && !cristalRecolectado)
        {
            if (Input.GetKey(KeyCode.E))
            {
                tiempoPresionando += Time.deltaTime;
                Debug.Log("Tiempo presionando E: " + tiempoPresionando);

                if (tiempoPresionando >= tiempoRequerido)
                {
                    RecolectarObject();
                }
            }
            else
            {
                if (tiempoPresionando > 0)
                {
                    Debug.Log("Se interrumpió el tiempo para recolectar.");
                }
                tiempoPresionando = 0f;
            }
        }
    }

    private void RecolectarObject()
    {
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        PlayerController playerController = player.GetComponent<PlayerController>();
        if (playerController != null)
        {
            if (gameObject.CompareTag("CristalMEMORIA") && !cristalRecolectado)
            {
                playerController.RecolectarObjeto();
                cristalRecolectado = true;
                LlaveOne.SetActive(true);

                if (dialogueTrigger != null && dialogueTrigger.PanelDialogoM2 != null)
                {
                    dialogueTrigger.PanelDialogoM2.SetActive(true);
                    Debug.Log("PanelDialogoM2 activado desde EInteraction.");

                }

                if (sonidoCRISTAL != null && audioSourceCRISTAL != null)
                {
                    audioSourceCRISTAL.PlayOneShot(sonidoCRISTAL);
                }

            }
            else if (gameObject.CompareTag("Objeto2") && !LlaveDeAcceso1Recolectada)
            {
                playerController.RecolectarLlaves();
                LlaveDeAcceso1Recolectada = true;

                PuertaOne.SetActive(false);
                PuertaVisualOne.SetActive(false);
                PuertaVisualOnePT2.SetActive(true);


                if (sonidoLlave != null && audioSourceKey != null)
                {
                    audioSourceKey.PlayOneShot(sonidoLlave);
                    audioSourceDoors.clip = sonidoDOOR;
                    audioSourceDoors.Play();
                }

                M2.SetActive(false);

            }
            else if (gameObject.CompareTag("Objeto3") && !LlaveDeAcceso2Recolectada)
            {
                playerController.RecolectarLlaves();
                LlaveDeAcceso2Recolectada = true;

                PuertaTwo.SetActive(false);
                PuertaVisualTwo.SetActive(false);
                PuertaVisualTwoPT2.SetActive(true);

                if (sonidoLlave != null && audioSourceKey != null)
                {
                    audioSourceKey.PlayOneShot(sonidoLlave);
                    audioSourceDoors.clip = sonidoDOOR;
                    audioSourceDoors.Play();
                }

                M3RedRoom.SetActive(false);
                M3Trigger.SetActive(false);
            }

        }

        if (dialogueTrigger != null)
        {
            dialogueTrigger.TriggerDesactivar();
        }

        if (gameObject.CompareTag("CristalMEMORIA") && ObjetivoM != null)
        {
            ObjetivoM.SetActive(false);
        }
        else if (gameObject.CompareTag("Objeto2") && ObjetivoLLave1 != null)
        {
            ObjetivoLLave1.SetActive(false);
        }


        ObjetivoM.SetActive(false);

        Destroy(gameObject);
        Debug.Log("Objeto recolectado con exito");
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && !cristalRecolectado) 
        {
            jugadorCerca = true;
            Debug.Log("Mantén presionada 'E' por 2 segundos para recoger el objeto.");
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            jugadorCerca = false;
            tiempoPresionando = 0f;
            Debug.Log("Te alejaste del objeto.");
        }
    }
}
