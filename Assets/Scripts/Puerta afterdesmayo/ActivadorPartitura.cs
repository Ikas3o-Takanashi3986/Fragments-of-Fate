using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivadorPartitura : MonoBehaviour
{
    public PuzzlePartituraManager manager;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
            manager.MostrarPanel();
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
            manager.OcultarPanel();
    }
}
