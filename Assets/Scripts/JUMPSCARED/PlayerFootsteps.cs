using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFootsteps : MonoBehaviour
{
    private FPSPersonajePrincipalController controller;

    private AudioSource caminarSource;
    private AudioSource correrSource;

    void Start()
    {
        controller = GetComponent<FPSPersonajePrincipalController>();

        caminarSource = controller.audioSource;
        correrSource = controller.audioSourceRun;
    }

    void Update()
    {
        if (controller == null) return;

        float movX = Input.GetAxis("Horizontal");
        float movZ = Input.GetAxis("Vertical");
        bool isMoving = (movX != 0 || movZ != 0);
        bool isRunning = (Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift)) && isMoving;

        if (isMoving && !isRunning)
        {
            if (!caminarSource.isPlaying)
            {
                caminarSource.clip = controller.caminarClip;
                caminarSource.loop = true;
                caminarSource.Play();
            }

            if (correrSource.isPlaying)
                correrSource.Stop();
        }
        else if (isRunning)
        {
            if (!correrSource.isPlaying)
            {
                correrSource.clip = controller.correrClip;
                correrSource.loop = true;
                correrSource.Play();
            }

            if (caminarSource.isPlaying)
                caminarSource.Stop();
        }
        else
        {
            if (caminarSource.isPlaying)
                caminarSource.Stop();

            if (correrSource.isPlaying)
                correrSource.Stop();
        }
    }
}
