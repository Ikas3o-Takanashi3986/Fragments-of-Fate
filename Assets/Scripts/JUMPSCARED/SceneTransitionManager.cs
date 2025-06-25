using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneTransitionManager : MonoBehaviour
{
    public static SceneTransitionManager Instance;
    public string spawnPointName = "DefaultSpawn";

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject); 
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void SetSpawnPoint(string pointName)
    {
        spawnPointName = pointName;
    }
}
