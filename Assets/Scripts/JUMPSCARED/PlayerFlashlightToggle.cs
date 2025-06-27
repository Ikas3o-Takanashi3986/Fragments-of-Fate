using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFlashlightToggle : MonoBehaviour
{
    private Light flashlightLight;

    void Start()
    {
        flashlightLight = GetComponentInChildren<Light>();
        flashlightLight.enabled = false;
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            flashlightLight.enabled = !flashlightLight.enabled;
        }
    }
}
