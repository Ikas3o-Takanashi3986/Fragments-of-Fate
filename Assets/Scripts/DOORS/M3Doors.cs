using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class M3Doors : MonoBehaviour
{
    public GameObject[] PuertasCollider;

    public GameObject[] PuertasClosed;
    public GameObject[] PuertasOpen;

    public AudioSource audioSourceDoors;
    public AudioClip sonidoDOOR;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            foreach (GameObject puerta in PuertasClosed)
            {
                if (puerta != null)
                    puerta.SetActive(false);

            }


            foreach (GameObject collider in PuertasCollider)
            {
                if (collider != null)
                    collider.SetActive(false);

            }


            foreach (GameObject puerta in PuertasOpen)
            {
                if (puerta != null)
                    puerta.SetActive(true);

            }

            if (audioSourceDoors != null && sonidoDOOR != null)
            {
                audioSourceDoors.clip = sonidoDOOR;
                audioSourceDoors.Play();
            }
        }
    }

}
