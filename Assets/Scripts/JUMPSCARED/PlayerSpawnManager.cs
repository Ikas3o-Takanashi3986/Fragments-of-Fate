using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSpawnManager : MonoBehaviour
{
    void Start()
    {
        string targetSpawn = SceneTransitionManager.Instance.spawnPointName;
        GameObject spawnPoint = GameObject.Find(targetSpawn);

        if (spawnPoint != null)
        {
            GameObject player = GameObject.FindGameObjectWithTag("Player");
            player.transform.position = spawnPoint.transform.position;
            player.transform.rotation = spawnPoint.transform.rotation;
        }
        else
        {
            Debug.LogWarning("Punto de spawn no encontrado: " + targetSpawn);
        }
    }
}
