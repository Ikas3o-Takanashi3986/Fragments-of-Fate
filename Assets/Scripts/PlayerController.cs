using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public GameObject LlaveR;
    public GameObject LlaveA;
    public GameObject Object1;
    public GameObject Object2;

    public bool llaveRRecolectada = false;
    public bool llaveARecolectada = false;
    public bool objeto1Recolectado = false;
    public bool objeto2Recolectado = false;

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
        if (!objeto1Recolectado)
        {
            if (Object1 != null)
            {
                Object1.SetActive(false);
                objeto1Recolectado = true;
                Debug.Log("Objeto 1 Recolectado");
            }
        }
        else
        {
            Debug.Log("Obtuviste el objeto 1");
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
}