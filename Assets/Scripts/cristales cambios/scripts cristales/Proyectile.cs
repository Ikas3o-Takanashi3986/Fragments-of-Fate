using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Proyectile : MonoBehaviour
{
    public float speed = 100f;
    public float damage;


    public void SetDamage(float dmg)
    {
        damage = dmg;
    }

    void Update()
    {
        transform.Translate(Vector3.forward * speed * Time.deltaTime);
        Destroy(gameObject, 4f);
    }

    private void OnTriggerEnter(Collider other)
    {
        Enemy enemy = other.GetComponent<Enemy>();
        if (enemy != null)
        {
            enemy.TakeDamage(damage);
            Destroy(gameObject);
        }
    }
}
