using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivadorExterior : MonoBehaviour
{
    public CompassManager compassManager;

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && compassManager != null)
        {
            compassManager.SetInOpenArea(true);
        }
    }
}
