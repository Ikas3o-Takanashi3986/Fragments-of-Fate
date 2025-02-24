using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControllerCristal : MonoBehaviour
{
    public GameObject Cristal;
    public bool CristalRecolect = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void RecolectCristal()
    {
        if (!CristalRecolect)
        {
            if (Cristal != null)
            {
                CristalRecolect = true;
                Debug.Log("Recargada");
                
            }
        }
        else
        {
            Debug.Log("Cristal Recargado");
        }
    }
}
