using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Proyectile : MonoBehaviour
{
    public float speed = 100f;
    public float damage;


    void Update()
    {
        transform.Translate(Vector3.forward * speed * Time.deltaTime, Space.Self);
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
