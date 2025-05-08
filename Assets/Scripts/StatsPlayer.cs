using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StatsPlayer : MonoBehaviour
{

    public static StatsPlayer Instance;

    public static float vida = 100f;

    private bool fuegoActivo = false;
    private float tiempoDeDaño = 1f;
    private float tiempoDuracion = 4f;
    private float temporizadorDaño = 0f;
    private float temporizadorDuracion = 0f;

    private void Awake()
    {
        Instance = this;
    }

    void Start()
    {
        
    }


    void Update()
    {
        if (fuegoActivo)
        {
            temporizadorDuracion += Time.deltaTime;
            temporizadorDaño += Time.deltaTime;

            if (temporizadorDaño >= tiempoDeDaño)
            {
                vida -= 2f;
                temporizadorDaño = 0f;
                Debug.Log("Daño continuo de FUEGO recibido");

                if (vida <= 0)
                {
                    Time.timeScale = 0;
                    Debug.Log("Has perdido");
                }
            }


            if (temporizadorDuracion >= tiempoDuracion)
            {
                fuegoActivo = false;
                temporizadorDuracion = 0f;
                temporizadorDaño = 0f;
                Debug.Log("Efecto de fuego terminado");
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("FuegoEnemigo"))
        {
            if (!fuegoActivo)
            {
                fuegoActivo = true;
                temporizadorDuracion = 0f;
                temporizadorDaño = 0f;
                Debug.Log("Entró en contacto con FUEGO");
            }

            Destroy(other.gameObject);
        }

        if (other.CompareTag("PlantaEnemigo"))
        {
            vida -= 4f;
            Destroy(other.gameObject);
            Debug.Log("Daño de PLANTA recibido");
        }

        if (other.CompareTag("HieloEnemigo"))
        {
            vida -= 10f;
            Destroy(other.gameObject);
            Debug.Log("Daño de HIELO recibido");
        }

        if (other.CompareTag("AguaEnemigo"))
        {
            vida -= 5f;
            Destroy(other.gameObject);
            Debug.Log("Daño de AGUA recibido");
        }


        if (vida <= 0)
        {
            Time.timeScale = 0;
            Debug.Log("Has perdido");
        }
    }

}
