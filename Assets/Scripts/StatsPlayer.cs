using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StatsPlayer : MonoBehaviour
{
    
    public  float vida = 20f;


    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.tag == "FuegoEnemigo")
        {
            vida = vida - 1f;
            Destroy(collision.transform.gameObject);

            if (vida == 0)
            {
                Debug.Log("Has perdido");
                Time.timeScale = 0;
                
            }

            if (collision.transform.tag == "PlantaEnemigo")
            {
                vida = vida - 1f;
                Destroy(collision.transform.gameObject);

                if (vida == 0)
                {
                    Debug.Log("Has perdido");
                    Time.timeScale = 0;

                }

            }

            if (collision.transform.tag == "HieloEnemigo")
            {
                vida = vida - 1f;
                Destroy(collision.transform.gameObject);

                if (vida == 0)
                {
                    Debug.Log("Has perdido");
                    Time.timeScale = 0;

                }

            }

            if (collision.transform.tag == "AguaEnemigo")
            {
                vida = vida - 1f;
                Destroy(collision.transform.gameObject);

                if (vida == 0)
                {
                    Debug.Log("Has perdido");
                    Time.timeScale = 0;

                }

            }

        }

    }
}
