using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PREM3Buscar : MonoBehaviour
{
    public AudioSource EntroAlArea;

    private void OnTriggerEnter(Collider other)
    {

        if (other.CompareTag("Player"))
        {

            if (EntroAlArea != null)
            {
                EntroAlArea.Play();
            }

        }
    }

}


