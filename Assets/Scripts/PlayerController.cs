using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public GameObject LlaveR;
    public GameObject LlaveA;

    private bool llaveRRecolectada = false;
    private bool llaveARecolectada = false;

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
}