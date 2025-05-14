using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrystalPickup : MonoBehaviour
{
    public CrystalData crystalData;

    private void OnTriggerEnter(Collider other)
    {
        CrystalInventory inventory = other.GetComponent<CrystalInventory>();
        if (inventory != null)
        {
            inventory.AddCrystal(crystalData);
            Destroy(gameObject);
        }
    }
}
