using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class ObjectSimpleInfo : MonoBehaviour
{
    public GameObject uiPromptPrefab;
    public string objectName = "Objeto";
    public string actionText = "Presiona E para ver";

    private GameObject promptInstance;
    private bool playerInRange = false;
    private Transform player;

    void Start()
    {
        if (uiPromptPrefab)
        {
            promptInstance = Instantiate(uiPromptPrefab);
            promptInstance.transform.SetParent(GameObject.Find("Canvas").transform, false);
            promptInstance.SetActive(false);

            TextMeshProUGUI[] texts = promptInstance.GetComponentsInChildren<TextMeshProUGUI>();
            if (texts.Length >= 2)
            {
                texts[0].text = objectName;
                texts[1].text = actionText;
            }
        }
    }

    void Update()
    {
        if (playerInRange && Input.GetKeyDown(KeyCode.E))
        {
            if (promptInstance) Destroy(promptInstance);
            Destroy(this);
        }

        if (promptInstance != null && playerInRange && player != null)
        {
            Vector3 offset = new Vector3(0, 0.3f, 0); 
            Vector3 worldPos = transform.position + offset;
            Vector3 screenPos = Camera.main.WorldToScreenPoint(worldPos);

            if (screenPos.z > 0)
            {
                promptInstance.transform.position = screenPos;
                promptInstance.SetActive(true);
            }
            else
            {
                promptInstance.SetActive(false); 
            }
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
}
