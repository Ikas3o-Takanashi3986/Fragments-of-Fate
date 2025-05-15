using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class StatsPlayer : MonoBehaviour
{


    public static StatsPlayer Instance;

    public static float vida = 100f;

    private bool fuegoActivo = false;
    private float tiempoDeDa�o = 1f;
    private float tiempoDuracion = 4f;
    private float temporizadorDa�o = 0f;
    private float temporizadorDuracion = 0f;

    public GameObject Load;
    public float tiempoEspera = 60f;
    public Image barraCarga;

    private float temporizador = 0f;

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
            temporizadorDa�o += Time.deltaTime;

            if (temporizadorDa�o >= tiempoDeDa�o)
            {
                vida -= 2f;
                temporizadorDa�o = 0f;
                Debug.Log("Da�o continuo de FUEGO recibido. Vida: " + vida);

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
                temporizadorDa�o = 0f;
                Debug.Log("Efecto de FUEGO finalizado");
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
                temporizadorDa�o = 0f;
                Debug.Log("Entr� en contacto con el FUEGO");
            }

            Destroy(other.gameObject);
        }

        if (other.CompareTag("PlantaEnemigo"))
        {
            vida -= 4f;
            Destroy(other.gameObject);
            Debug.Log("Da�o de PLANTA recibido");

            if (vida <= 0)
            {
                Time.timeScale = 0;
                Debug.Log("Has perdido");
            }
        }

        if (other.CompareTag("HieloEnemigo"))
        {
            vida -= 10f;
            Destroy(other.gameObject);
            Debug.Log("Da�o de HIELO recibido");

            if (vida <= 0)
            {
                Time.timeScale = 0;
                Debug.Log("Has perdido");
            }
        }

        if (other.CompareTag("AguaEnemigo"))
        {
            vida -= 5f;
            Destroy(other.gameObject);
            Debug.Log("Da�o de AGUA recibido");

            if (vida <= 0)
            {
                Time.timeScale = 0;
                Debug.Log("Has perdido");
            }
        }
    }

    public void CargarEscena1()
    {

        StartCoroutine(CargarConBarra());

        Destroy(Load);
    }

    IEnumerator CargarConBarra()
    {

        temporizador = 0f;
        barraCarga.fillAmount = 0f;


        while (temporizador < tiempoEspera)
        {
            temporizador += Time.deltaTime * 0.5f;
            barraCarga.fillAmount = temporizador / tiempoEspera;
            yield return null;
        }


        CargarEscena();
    }

    void CargarEscena()
    {
        SceneManager.LoadScene(1);
    }

}
