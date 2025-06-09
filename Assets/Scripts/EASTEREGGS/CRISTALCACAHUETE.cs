using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CRISTALCACAHUETE : MonoBehaviour
{
    public AudioSource sonidoRecogida;   
    public float altura = 0.5f;         
    public float velocidad = 2f;      

    private Vector3 posicionInicial;

    void Start()
    {
        posicionInicial = transform.position;
    }

    void Update()
    {
        float desplazamiento = Mathf.Sin(Time.time * velocidad) * altura;
        transform.position = new Vector3(
            posicionInicial.x,
            posicionInicial.y + desplazamiento,
            posicionInicial.z
        );
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (sonidoRecogida != null)
            {
                sonidoRecogida.Play();
            }

            Destroy(gameObject); 
        }
    }
}