using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlCristalLuz : MonoBehaviour
{
    public Light lightToControl;
    public float lightOnDuration = 5f;

    private Light currentLight;
    private Renderer currentLightRenderer;
    
    void Start()
    {
        currentLight = GetComponentInChildren<Light>();

        currentLightRenderer = GetComponentInChildren<Renderer>();
        if (currentLightRenderer != null)
        {
            currentLightRenderer.material.color = Color.gray;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnMouseDown()
    {
        StartCoroutine(TurnOffAndOnLight());
    }

    private IEnumerator TurnOffAndOnLight()
    {
        currentLight.enabled = false;

        if (currentLightRenderer != null)
        {
            currentLightRenderer.material.color = Color.gray;
        }

        lightToControl.enabled = true;

        Renderer lightToControlRenderer = lightToControl.GetComponentInChildren<Renderer>();
        if (lightToControlRenderer != null)
        {
            lightToControlRenderer.material.color = Color.white;
        }

        yield return new WaitForSeconds(lightOnDuration);

        lightToControl.enabled = false;

        if (lightToControlRenderer != null)
        {
            lightToControlRenderer.material.color = Color.gray;
        }
    }

}
