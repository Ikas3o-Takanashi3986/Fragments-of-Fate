using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickableObject : MonoBehaviour
{
    public CompassManager compassManager;
    public KeyCode pickUpKey = KeyCode.E;

    private bool playerInRange = false;

    void Update()
    {
        if (playerInRange && Input.GetKeyDown(pickUpKey))
        {
            if (compassManager != null)
            {
                compassManager.GiveCompass();
                Destroy(gameObject); 
            }
            else
            {
                Debug.LogWarning("CompassManager no asignado en PickableObject");
            }
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerInRange = true;
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerInRange = false;
        }
    }
}
