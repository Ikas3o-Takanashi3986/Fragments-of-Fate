using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FlashlightPickup : MonoBehaviour
{
    public GameObject playerFlashlightPrefab;
    public GameObject interactionUI;
    public AudioClip pickupSound;
    private bool isPlayerNearby = false;
    private AudioSource audioSource;

    void Start()
    {
        interactionUI.SetActive(false);


        audioSource = GetComponent<AudioSource>();
        if (audioSource == null)
        {
            audioSource = gameObject.AddComponent<AudioSource>();
        }
    }

    void Update()
    {
        if (isPlayerNearby && Input.GetKeyDown(KeyCode.E))
        {
            
            Camera playerCam = Camera.main;
            if (playerCam != null)
            {
                GameObject flashlight = Instantiate(playerFlashlightPrefab);

                
                flashlight.transform.SetParent(playerCam.transform, false);

               
                flashlight.transform.localPosition = new Vector3(0.434f, -0.374f, 0.813f); 
                flashlight.transform.localRotation = Quaternion.identity;


                if (pickupSound != null)
                {
                    audioSource.PlayOneShot(pickupSound);
                }

                interactionUI.SetActive(false);
                gameObject.SetActive(false);
            }
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isPlayerNearby = true;
            interactionUI.SetActive(true);
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isPlayerNearby = false;
            interactionUI.SetActive(false);
        }
    }
}
