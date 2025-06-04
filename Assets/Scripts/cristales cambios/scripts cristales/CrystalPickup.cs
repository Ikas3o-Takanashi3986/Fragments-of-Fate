using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrystalPickup : MonoBehaviour
{
    public CrystalData crystalData;
    public GameObject uiPromptPrefab;

    private GameObject promptInstance;
    private bool playerInRange = false;
    private Transform player;

    void Start()
    {

        if (uiPromptPrefab)
        {
            promptInstance = Instantiate(uiPromptPrefab, transform.position + Vector3.up * 0.3f, Quaternion.identity);
            promptInstance.transform.SetParent(GameObject.Find("Canvas").transform, false);
            promptInstance.SetActive(false);
        }
    }

    void Update()
    {
        if (playerInRange && Input.GetKeyDown(KeyCode.E))
        {
            TryPickup();
        }

        if (promptInstance != null && playerInRange && player != null)
        {
            Vector3 screenPos = Camera.main.WorldToScreenPoint(transform.position + Vector3.up * 0.3f);
            promptInstance.transform.position = screenPos;
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerInRange = true;
            player = other.transform;

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

    void TryPickup()
    {
        if (player == null) return;

        CrystalInventory inventory = player.GetComponent<CrystalInventory>();
        if (inventory != null && crystalData != null)
        {
            inventory.AddCrystal(crystalData);
            if (promptInstance != null) Destroy(promptInstance);
            Destroy(gameObject);
        }
    }
}
