using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ObjectInteractMessage : MonoBehaviour
{
    public GameObject uiPromptPrefab;      
    public GameObject infoPanelPrefab;     
    public string objectName = "Objeto Misterioso";
    public string actionText = "Presiona E para interactuar";
    [TextArea] public string objectInfo = "Este objeto contiene información importante...";

    private GameObject promptInstance;
    private GameObject infoPanelInstance;
    private bool playerInRange = false;
    private Transform player;
    private bool infoShown = false;

    void Start()
    {
        if (uiPromptPrefab)
        {
            promptInstance = Instantiate(uiPromptPrefab);
            promptInstance.transform.SetParent(GameObject.Find("Canvas").transform, false);
            promptInstance.SetActive(false);

            // Asignar texto
            TextMeshProUGUI[] texts = promptInstance.GetComponentsInChildren<TextMeshProUGUI>();
            if (texts.Length >= 2)
            {
                texts[0].text = objectName;
                texts[1].text = actionText;
            }
        }

        if (infoPanelPrefab)
        {
            infoPanelInstance = Instantiate(infoPanelPrefab);
            infoPanelInstance.transform.SetParent(GameObject.Find("Canvas").transform, false);
            infoPanelInstance.SetActive(false);

            TextMeshProUGUI text = infoPanelInstance.GetComponentInChildren<TextMeshProUGUI>();
            if (text != null) text.text = objectInfo;
        }
    }

    void Update()
    {
        
        if (playerInRange && !infoShown && Input.GetKeyDown(KeyCode.E))
        {
            ShowInfo();
        }

        
        if (infoShown && Input.GetKeyDown(KeyCode.R))
        {
            CloseInfo();
        }

        
        if (promptInstance != null && playerInRange && !infoShown)
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

            if (promptInstance != null && !infoShown)
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

    void ShowInfo()
    {
        infoShown = true;

        if (promptInstance) Destroy(promptInstance);
        if (infoPanelInstance) infoPanelInstance.SetActive(true);

        Time.timeScale = 0f;
    }

    void CloseInfo()
    {
        if (infoPanelInstance) Destroy(infoPanelInstance);
        Time.timeScale = 1f;
        Destroy(this);
    }
}
