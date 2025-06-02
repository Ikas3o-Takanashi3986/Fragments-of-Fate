using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NewCrystal", menuName = "Crystal")]

public class CrystalData : ScriptableObject
{

    public string crystalName;
    public Sprite icon;
    public GameObject visualPrefab;
    public GameObject projectilePrefab;
    public float proyectileDamage;
}
