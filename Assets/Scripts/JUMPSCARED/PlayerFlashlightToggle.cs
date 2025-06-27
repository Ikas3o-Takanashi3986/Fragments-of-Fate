using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFlashlightToggle : MonoBehaviour
{
    private Light flashlightLight;
    public AudioClip sonidoEncender;
    public AudioClip sonidoApagar;

    private AudioSource audioSource;

    void Start()
    {
        flashlightLight = GetComponentInChildren<Light>();
        flashlightLight.enabled = false;

        audioSource = GetComponent<AudioSource>();
        if (audioSource == null)
        {
            audioSource = gameObject.AddComponent<AudioSource>();
        }
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            flashlightLight.enabled = !flashlightLight.enabled;


            if (flashlightLight.enabled && sonidoEncender != null)
            {
                audioSource.PlayOneShot(sonidoEncender);
            }
            else if (!flashlightLight.enabled && sonidoApagar != null)
            {
                audioSource.PlayOneShot(sonidoApagar);
            }
        }
    }
}
