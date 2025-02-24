using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RecargaCristal : MonoBehaviour
{
    private bool jugadorCerca = false;
    private float tiempoPresionando = 0f;
    private float tiempoRequerido = 1f;
    

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (jugadorCerca)
        {
            if (Input.GetKey(KeyCode.R))
            {
                tiempoPresionando += Time.deltaTime;
                Debug.Log("Tiempo presionando R: " + tiempoPresionando);

                if (tiempoPresionando >= tiempoRequerido)
                {
                    Recolectcristals();

                }
            }
            else
            {
                if (tiempoPresionando > 0)
                {
                    Debug.Log("Recarga Incompleta");
                }
                tiempoPresionando = 0f;
            }
        }
    }

    private void Recolectcristals()
    {
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        ControllerCristal ControllerCristal = player.GetComponent<ControllerCristal>();
        if (ControllerCristal != null)
        {
            if (gameObject.CompareTag("Cristal"))
            {
                ControllerCristal.RecolectCristal();
            }
            
        }
        
        Debug.Log("Cristal Recargado");
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            jugadorCerca = true;
            Debug.Log("Mantén presionada 'R' por 1 segundo para recargar cristal");
        }
    }


}
