using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShooterCrystal : MonoBehaviour
{
    public CrystalInventory inventory;
    public Transform firePoint;


    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Shoot();
        }

        float scroll = Input.GetAxis("Mouse ScrollWheel");
        if (scroll != 0)
        {
            inventory.ChangeCrystal(scroll);
        }
    }

    void Shoot()
    {
        CrystalData current = inventory.GetActiveCrystal();
        if (current != null && current.projectilePrefab != null)
        {
            GameObject projectile = Instantiate(current.projectilePrefab, firePoint.position, firePoint.rotation);

            Proyectile p = projectile.GetComponent<Proyectile>();
            if (p != null)
            {
                p.SetDamage(current.proyectileDamage);
            }
        }
    }
}
