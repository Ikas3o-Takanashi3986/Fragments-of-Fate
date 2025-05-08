using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamaraPersonajePrincipal : MonoBehaviour
{
    public float sensibilidad;
    public GameObject player;
    private float XRotation = 0f;

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = true;
    }


    void Update()
    {
        float mouseX = Input.GetAxis("Mouse X") * sensibilidad * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * sensibilidad * Time.deltaTime;



        XRotation -= mouseY;
        XRotation = Mathf.Clamp(XRotation, -90f, 90f);


        transform.localRotation = Quaternion.Euler(XRotation, 0, 0);

        player.transform.Rotate(Vector3.up * mouseX);
    }
}
