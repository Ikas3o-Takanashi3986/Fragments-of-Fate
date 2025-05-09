using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Objective : MonoBehaviour
{
    private bool jugadorCerca = false;
    private int objetivoID = 0;
    private PlayerController playerController;

    public DialogueTrigger dialogueTrigger;

    void Start()
    {
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        if (player != null)
        {
            playerController = player.GetComponent<PlayerController>();
        }
    }


    void Update()
    {
        Objetivo();
    }

    private void Objetivo()
    {
        if (jugadorCerca)
        {
            if (jugadorCerca && Input.GetKeyDown(KeyCode.U))
            {
                bool cristalRecolectado = playerController != null && playerController.CristalMRecolectado;
                bool mapa1Recolectado = playerController != null && playerController.mapa1Recolectado;
                bool mapa2Recolectado = playerController != null && playerController.mapa2Recolectado;
                bool LlaveDeAcceso1Recolectada = playerController != null && playerController.LlaveDeAcceso1Recolectada;

                if (objetivoID == 1)
                {
                    if (!cristalRecolectado)
                    {
                        Debug.Log("Recoge el CRISTAL de la MEMORIA");
                        if (dialogueTrigger != null)
                        {
                            dialogueTrigger.TriggerDialogue();
                        }
                    }
                    else
                    {
                        Debug.Log("Ya tienes el CRISTAL de la MEMORIA");
                    }
                }
                else if (objetivoID == 2)
                {
                    if (!LlaveDeAcceso1Recolectada)
                    {
                        Debug.Log("Consigue la LLave de ACCESO");
                        if (dialogueTrigger != null)
                        {
                            dialogueTrigger.TriggerDialogue();
                        }
                    }
                    else
                    {
                        Debug.Log("Ya tienes la Llave 1");
                    }

                }
                else if (objetivoID == 3)
                {
                    if (mapa1Recolectado && mapa2Recolectado)
                    {
                        Debug.Log("¡Ya tienes el MAPA COMPLETO!");
                    }
                    else if (!mapa1Recolectado && !mapa2Recolectado)
                    {
                        Debug.Log("Encuentra las 2 PIEZAS del MAPA");
                    }
                    else if (mapa1Recolectado && !mapa2Recolectado)
                    {
                        Debug.Log("Tienes la PRIMERA pieza del MAPA.");
                    }
                    else if (!mapa1Recolectado && mapa2Recolectado)
                    {
                        Debug.Log("Tienes la SEGUNDA pieza del MAPA.");
                    }
                }
            }
        }
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            jugadorCerca = true;

            if (gameObject.name == "Objetivo1")
            {
                objetivoID = 1;
            }
            else if (gameObject.name == "Objetivo2")
            {
                objetivoID = 2;
            }
            else if (gameObject.name == "Objetivo3")
            {
                objetivoID = 3;
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            jugadorCerca = false;
        }
    }
}
