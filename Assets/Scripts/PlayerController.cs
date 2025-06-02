using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public GameObject LlaveR;
    public GameObject LlaveA;
    public GameObject Object1;
    public GameObject Object2;
    public GameObject Mapa1;
    public GameObject Mapa2;
    public GameObject Llave1;

    public bool llaveRRecolectada = false;
    public bool llaveARecolectada = false;
    public bool CristalMRecolectado = false;
    public bool objeto2Recolectado = false;
    public bool mapa1Recolectado = false;
    public bool mapa2Recolectado = false;
    public bool LlaveDeAcceso1Recolectada = false;

    public AudioSource audioSourceMapa;
    public AudioClip sonidoAbrirMapa;
    public AudioClip sonidoCerrarMapa;

    public GameObject mapaDisplayContenedor3D;
    public GameObject mapa1Modelo3D;
    public GameObject mapa2Modelo3D;
    public GameObject Luz;

    public GameObject Bloqueo1;

    private bool mapaVisible = false;

    void Update()
    {
        if ((mapa1Recolectado || mapa2Recolectado) && Input.GetKeyDown(KeyCode.M))
        {
            mapaVisible = !mapaVisible;

            if (mapaDisplayContenedor3D != null)
            {
                mapaDisplayContenedor3D.SetActive(mapaVisible);

                if (mapaVisible)
                {
                    if (mapa1Recolectado && mapa1Modelo3D != null)
                        mapa1Modelo3D.SetActive(true);

                    if (mapa2Recolectado && mapa2Modelo3D != null)
                        mapa2Modelo3D.SetActive(true);

                    Luz.SetActive(true);

                    if (audioSourceMapa != null && sonidoAbrirMapa != null)
                        audioSourceMapa.PlayOneShot(sonidoAbrirMapa);
                }
                else
                {
                    if (mapa1Modelo3D != null) mapa1Modelo3D.SetActive(false);
                    if (mapa2Modelo3D != null) mapa2Modelo3D.SetActive(false);

                    Luz.SetActive(false);

                    if (audioSourceMapa != null && sonidoCerrarMapa != null)
                        audioSourceMapa.PlayOneShot(sonidoCerrarMapa);
                }
            }
        }
    }


    public void RecolectarLlaveR()
    {
        if (!llaveRRecolectada)
        {
            if (LlaveR != null) 
            {
                LlaveR.SetActive(false);
                llaveRRecolectada = true;
                Debug.Log("LlaveR recolectada.");
            }
        }
        else
        {
            Debug.Log("Ya tienes la LlaveR.");
        }
    }

    public void RecolectarLlaveA()
    {
        if (!llaveARecolectada)
        {
            if (LlaveA != null)
            {
                LlaveA.SetActive(false);
                llaveARecolectada = true;
                Debug.Log("LlaveA recolectada.");
            }
        }
        else
        {
            Debug.Log("Ya tienes la LlaveA.");
        }
    }

    public void RecolectarObjeto()
    {
        if (!CristalMRecolectado)
        {
            if (Object1 != null)
            {
                Object1.SetActive(false);
                CristalMRecolectado = true;
                Debug.Log("Cristal M Recolectado");
            }
        }
        else
        {
            Debug.Log("Obtuviste el Cristal M");
        }
    }

    public void RecolectarObjeto2()
    {
        if (!objeto2Recolectado)
        {
            if (Object2 != null)
            {
                Object2.SetActive(false);
                objeto2Recolectado = true;
                Debug.Log("Objeto 2 Recolectado");
            }
        }
        else
        {
            Debug.Log("Obtuviste el objeto 2");
        }
    }

    public void RecolectarMapa1()
    {
        if (!mapa1Recolectado)
        {
            if (Mapa1 != null)
            {
                Mapa1.SetActive(false);
                mapa1Recolectado = true;

                Bloqueo1.SetActive(false);

                Debug.Log("Mapa 1 recolectado.");
            }
        }
    }

    public void RecolectarMapa2()
    {
        if (!mapa2Recolectado)
        {
            if (Mapa2 != null)
            {
                Mapa2.SetActive(false);
                mapa2Recolectado = true;
                Debug.Log("Mapa 2 recolectado.");
            }
        }
    }

    public void RecolectarLlaves()
    {
        if (!LlaveDeAcceso1Recolectada)
        {
            if (Llave1 != null)
            {
                Llave1.SetActive(false);
                LlaveDeAcceso1Recolectada = true;
                Debug.Log("Llave 1 Recolectada.");
            }
            else
            {
                Debug.Log("Obtuviste la Llave 1");
            }
        }
    }


}