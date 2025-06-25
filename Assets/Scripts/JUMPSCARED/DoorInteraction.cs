using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DoorInteraction : MonoBehaviour
{
    public string nextScene = "Fragments-of-Fate";
    public string spawnPointInNextScene = "DefaultSpawn";

    void OnTriggerEnter(Collider other)
    {
        if (!other.CompareTag("Player")) return;

        if (GameManager.Instance.hasKey)
        {
            SceneTransitionManager.Instance.SetSpawnPoint(spawnPointInNextScene);
            SceneManager.LoadScene(nextScene);
        }
        else
        {
            GameManager.Instance.ShowNeedKeyMessage();
        }
    }
}
