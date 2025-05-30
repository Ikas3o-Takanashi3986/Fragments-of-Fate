using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawnRedRoom : MonoBehaviour
{
    public GameObject[] enemigos;


    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            foreach (GameObject enemigo in enemigos)
            {
                if (enemigo != null)
                {
                    enemigo.SetActive(true);
                }
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            foreach (GameObject enemigo in enemigos)
            {
                if (enemigo != null)
                {
                    enemigo.SetActive(false);
                }
            }
        }
    }
}
