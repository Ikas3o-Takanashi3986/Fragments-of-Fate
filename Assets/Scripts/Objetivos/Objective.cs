using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Objective : MonoBehaviour
{
    private bool jugadorCerca = false;
    private int objetivoID = 0;

    void Start()
    {
        
    }


    void Update()
    {
        Objetivo();
    }

    private void Objetivo()
    {
        if (jugadorCerca)
        {
            if (Input.GetKeyDown(KeyCode.U))
            {
               if (objetivoID == 1)
               {
                    Debug.Log("Recoge el CRISTAL de la MEMORIA");
               }
               else if (objetivoID == 2)
               {
                    Debug.Log("Consigue la LLave de ACCESO");
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
