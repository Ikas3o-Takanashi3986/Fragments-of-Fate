using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CodigoProyectilFuego : MonoBehaviour
{
    public float velocidad = 90f;


    void Start()
    {
 
        //Destroy(gameObject, 9f);
    }


    void Update()
    {

        transform.Translate(Vector3.forward * Time.deltaTime * velocidad);
    }
}
