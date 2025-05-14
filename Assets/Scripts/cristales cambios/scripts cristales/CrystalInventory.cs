using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrystalInventory : MonoBehaviour
{
    public List<CrystalData> collectedCrystals = new List<CrystalData>();
    public int currentIndex = 0;

    public void AddCrystal(CrystalData crystal)
    {
        if (!collectedCrystals.Contains(crystal))
        {
            collectedCrystals.Add(crystal);
        }
    }

    public CrystalData GetActiveCrystal() //1
    {
        if (collectedCrystals.Count == 0) return null;
        return collectedCrystals[currentIndex];
    }

    public void ChangeCrystal(float direction) //2
    {
        if (collectedCrystals.Count == 0) return;

        if (direction > 0)
            currentIndex = (currentIndex + 1) % collectedCrystals.Count;
        else
            currentIndex = (currentIndex - 1 + collectedCrystals.Count) % collectedCrystals.Count;
    }
}
