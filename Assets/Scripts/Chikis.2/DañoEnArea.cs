using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DañoEnArea : MonoBehaviour
{
    public float dañoPorSegundo = 5f;

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            StatsPlayer stats = other.GetComponent<StatsPlayer>();
            if (stats != null)
            {
                stats.RecibirDañoContinuo(dañoPorSegundo * Time.deltaTime);
            }
        }
    }
}