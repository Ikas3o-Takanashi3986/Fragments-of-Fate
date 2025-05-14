using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrystalVisualManager : MonoBehaviour
{
    public CrystalInventory inventory;
    public Transform crystalVisualHolder;

    private GameObject currentVisual;

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        var activeCrystal = inventory.GetActiveCrystal();
        if (activeCrystal != null)
        {
            if (currentVisual == null || currentVisual.name != activeCrystal.visualPrefab.name)
            {
                UpdateVisual(activeCrystal.visualPrefab);
            }
        }
    }

    void UpdateVisual(GameObject newVisual)
    {
        if (currentVisual != null)
        {
            Destroy(currentVisual);
        }

        currentVisual = Instantiate(newVisual, crystalVisualHolder);
        currentVisual.name = newVisual.name;

        currentVisual.transform.localPosition = Vector3.zero;
        currentVisual.transform.localRotation = Quaternion.identity;
    }
}
