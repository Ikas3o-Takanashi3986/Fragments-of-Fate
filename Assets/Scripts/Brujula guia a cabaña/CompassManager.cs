using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CompassManager : MonoBehaviour
{
    public GameObject compassUI;
    public Transform player;
    public Transform target;
    public RectTransform arrow;
    public TMP_Text messageText;

    public float distanceToDisable = 5f;  
    public KeyCode activateKey = KeyCode.D;  

    public bool isInOpenArea = false;   
    private bool hasCompass = false;      
    private bool yaEstuvoEnZonaAbierta = false;

    void Update()
    {
        if (hasCompass)
        {
            if (Input.GetKeyDown(activateKey))
            {
                
                if (isInOpenArea || yaEstuvoEnZonaAbierta)
                {
                    compassUI.SetActive(!compassUI.activeSelf);
                }
                else
                {
                    
                    StartCoroutine(ShowMessage("Creo que necesito estar en un espacio abierto para usarlo", 6f));
                }
            }
        }

        if (!compassUI.activeSelf) return;

        Vector3 toTarget = target.position - player.position;
        toTarget.y = 0f;

        Vector3 forward = player.forward;
        forward.y = 0f;

        float angle = Vector3.SignedAngle(forward, toTarget.normalized, Vector3.up);
        arrow.localRotation = Quaternion.Euler(0, 0, -angle);

        float distanceToTarget = Vector3.Distance(player.position, target.position);
        if (distanceToTarget <= distanceToDisable)
        {
            compassUI.SetActive(false);
            StartCoroutine(ShowMessage("Has llegado", 3f));
        }
    }

    public void SetInOpenArea(bool state)
    {
        isInOpenArea = state;

        if (isInOpenArea)
        {
            yaEstuvoEnZonaAbierta = true; 

            if (hasCompass)
            {
                StartCoroutine(ShowMessage("Puedo guiarme con la brújula\nPresiona D", 6f));
            }
        }
    }

    public void GiveCompass()
    {
        hasCompass = true;
        StartCoroutine(ShowMessage("Brújula obtenida", 3f));
    }

    IEnumerator ShowMessage(string message, float duration)
    {
        messageText.text = message;
        messageText.gameObject.SetActive(true);
        yield return new WaitForSeconds(duration);
        messageText.gameObject.SetActive(false);
    }
}
