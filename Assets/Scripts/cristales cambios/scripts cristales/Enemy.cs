using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float health = 50f;

    public float da�oHielo = 1f;
    public float da�oAgua = 2f;
    public float da�oFuego = 3f;

    public void TakeDamage(float amount)
    {
        health -= amount;
        Debug.Log("Recibi� " + amount + " de da�o. Vida actual: " + health);

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
            TakeDamage(da�oHielo);
        }
        else if (tag == "CritalAgua")
        {
            TakeDamage(da�oAgua);
        }
        else if (tag == "CritalFuego")
        {
            TakeDamage(da�oFuego);
        }
    }
}
