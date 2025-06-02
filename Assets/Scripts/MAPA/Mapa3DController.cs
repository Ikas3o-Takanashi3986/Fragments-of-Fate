using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mapa3DController : MonoBehaviour
{
    public float zoomSpeed = 0.1f; 
    public float minZLocal = 0.1f;  
    private float maxZLocal;  

    private Vector3 initialLocalPosition;

    void Start()
    {

        initialLocalPosition = transform.localPosition;
        maxZLocal = initialLocalPosition.z;
    }

    void Update()
    {
        float scroll = Input.GetAxis("Mouse ScrollWheel");

        if (scroll != 0f)
        {

            float newZ = transform.localPosition.z + scroll * zoomSpeed;


            newZ = Mathf.Clamp(newZ, minZLocal, maxZLocal);


            transform.localPosition = new Vector3(transform.localPosition.x, transform.localPosition.y, newZ);
        }

    }
}
