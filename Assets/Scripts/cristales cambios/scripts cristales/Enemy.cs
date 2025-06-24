using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float health = 50f;

    public float dañoHielo = 1f;
    public float dañoAgua = 2f;
    public float dañoFuego = 3f;

    public void TakeDamage(float amount)
    {
        health -= amount;
        Debug.Log("Recibió " + amount + " de daño. Vida actual: " + health);

        if (health <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
        Debug.Log("Enemigo destruido");
        Destroy(gameObject);
    }

    private void OnCollisionEnter(Collision collision)
    {
        string tag = collision.transform.tag;

        if (tag == "CritalHielo")
        {
            TakeDamage(dañoHielo);
        }
        else if (tag == "CritalAgua")
        {
            TakeDamage(dañoAgua);
        }
        else if (tag == "CritalFuego")
        {
            TakeDamage(dañoFuego);
        }
    }
}
