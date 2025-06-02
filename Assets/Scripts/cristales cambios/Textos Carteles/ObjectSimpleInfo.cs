using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectSimpleInfo : MonoBehaviour
{
    public GameObject uiPromptPrefab;  
    private GameObject promptInstance;

    private bool playerInRange = false;
    private Transform player;

    void Start()
    {
        if (uiPromptPrefab)
        {
            
            promptInstance = Instantiate(uiPromptPrefab, transform.position + Vector3.up * 2f, Quaternion.identity);
            promptInstance.transform.SetParent(GameObject.Find("Canvas").transform, false);
            promptInstance.SetActive(false);
        }
    }

    void Update()
    {
        if (playerInRange && Input.GetKeyDown(KeyCode.E))
        {
            HideMessage();
        }

       
        if (promptInstance != null && playerInRange && player != null)
        {
            Vector3 screenPos = Camera.main.WorldToScreenPoint(transform.position + Vector3.up * 2f);
            promptInstance.transform.position = screenPos;
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            player = other.transform;
            playerInRange = true;
            if (promptInstance != null)
                promptInstance.SetActive(true);
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerInRange = false;
            player = null;
            if (promptInstance != null)
                promptInstance.SetActive(false);
        }
    }

    void HideMessage()
    {
        if (promptInstance != null)
        {
            Destroy(promptInstance); 
        }
        Destroy(this); // Elimina el script para que no vuelva a activarse
    }
}
