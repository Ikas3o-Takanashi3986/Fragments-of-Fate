using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EInteraction : MonoBehaviour
{
    private bool jugadorCerca = false;
    private float tiempoPresionando = 0f;
    private float tiempoRequerido = 2f;
    private bool cristalRecolectado = false;
    private bool LlaveDeAcceso1Recolectada = false;

    public GameObject ObjetivoM;

    public DialogueTrigger dialogueTrigger;

    public AudioSource audioSourceKey;
    public AudioClip sonidoLlave;

    public AudioSource audioSourceCRISTAL;
    public AudioClip sonidoCRISTAL;

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

                if (sonidoCRISTAL != null && audioSourceCRISTAL != null)
                {
                    audioSourceCRISTAL.PlayOneShot(sonidoCRISTAL);
                }

            }
            else if (gameObject.CompareTag("Objeto2") && !LlaveDeAcceso1Recolectada)
            {
                playerController.RecolectarLlaves();
                LlaveDeAcceso1Recolectada = true;

                if (sonidoLlave != null && audioSourceKey != null)
                {
                    audioSourceKey.PlayOneShot(sonidoLlave);
                }
            }
        }

        if (dialogueTrigger != null)
        {
            dialogueTrigger.TriggerDesactivar();
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
