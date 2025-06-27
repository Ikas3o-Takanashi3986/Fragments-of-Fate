using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightFlicker : MonoBehaviour
{
    public Light lightSource;
    public float minIntensity = 2f;
    public float maxIntensity = 50f;
    public float flickerSpeed = 0.1f; 
    public bool randomize = true;     

    private float timer;

    void Start()
    {
        if (lightSource == null)
        {
            lightSource = GetComponent<Light>();
        }
    }

    void Update()
    {
        timer -= Time.deltaTime;
        if (timer <= 0f)
        {
            if (randomize)
            {
                lightSource.intensity = Random.Range(minIntensity, maxIntensity);
                timer = Random.Range(flickerSpeed / 2f, flickerSpeed * 2f);
            }
            else
            {
                lightSource.intensity = (lightSource.intensity == minIntensity) ? maxIntensity : minIntensity;
                timer = flickerSpeed;
            }
        }
    }
}
