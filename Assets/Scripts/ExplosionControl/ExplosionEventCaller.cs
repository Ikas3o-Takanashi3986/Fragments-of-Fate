using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosionEventCaller : MonoBehaviour
{
    public GameObject explosionPrefab;
    public Transform explosionSpawnPoint;

    public void ActivarExplosion()
    {
        if (explosionPrefab != null && explosionSpawnPoint != null)
        {
            Instantiate(explosionPrefab, explosionSpawnPoint.position, Quaternion.identity);
            Debug.Log("Explosión activada desde Animation Event");
        }
        else
        {
            Debug.LogWarning("Faltan explosionPrefab o explosionSpawnPoint asignados.");
        }
    }
}
