using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStatsA : MonoBehaviour
{
    public int vidaEnemy = 2;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.tag == "CritalHielo")
        {
            Debug.Log("Atack");
            vidaEnemy = vidaEnemy - 1;
            if (vidaEnemy == 0)
            {
                Destroy(gameObject);
            }
        }

        if (collision.transform.tag == "CritalFuego")
        {
            Debug.Log("Atack");
            vidaEnemy = vidaEnemy - 1;
            if (vidaEnemy == 0)
            {
                Destroy(gameObject);
            }
        }

        if (collision.transform.tag == "CritalAgua")
        {
            Debug.Log("Atack");
            vidaEnemy = vidaEnemy - 1;
            if (vidaEnemy == 0)
            {
                Destroy(gameObject);
            }
        }
    }
}
