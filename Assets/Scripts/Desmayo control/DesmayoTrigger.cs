using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DesmayoTrigger : MonoBehaviour
{
    public ControlCamaraDesmayo controlCamaraDesmayo;


    private bool yaDesmayo = false;

    private void OnTriggerEnter(Collider other)
    {
        if (!yaDesmayo && other.CompareTag("Player"))
        {
            yaDesmayo = true;
            controlCamaraDesmayo.IniciarSecuenciaCompleta();
        }
    }
}
