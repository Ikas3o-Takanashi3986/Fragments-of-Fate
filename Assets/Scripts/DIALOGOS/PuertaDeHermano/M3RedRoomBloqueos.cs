using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class M3RedRoomBloqueos : MonoBehaviour
{
    public GameObject M3REDROOM;
    public GameObject[] BloqueosR;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            foreach (GameObject Block in BloqueosR)
            {
                if (Block != null)
                    Block.SetActive(false);

            }

            M3REDROOM.SetActive(false);
        }

    }

}

