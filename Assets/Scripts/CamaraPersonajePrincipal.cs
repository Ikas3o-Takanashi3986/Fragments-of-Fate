using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamaraPersonajePrincipal : MonoBehaviour
{
    public float sensibilidad = 100f;
    public GameObject player;

    private float XRotation = 0f;
    private bool cursorLibre = false;

    // Parámetros del movimiento suave
    public float amplitudMovimiento = 0.01f;
    public float velocidadMovimiento = 1.5f;
    private Vector3 posicionInicial;

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        posicionInicial = transform.localPosition;
    }

    void Update()
    {
        MouseChange();

        float mouseX = Input.GetAxis("Mouse X") * sensibilidad * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * sensibilidad * Time.deltaTime;

        XRotation -= mouseY;
        XRotation = Mathf.Clamp(XRotation, -90f, 90f);

        transform.localRotation = Quaternion.Euler(XRotation, 0, 0);
        player.transform.Rotate(Vector3.up * mouseX);


        float movimientoY = Mathf.Sin(Time.time * velocidadMovimiento) * amplitudMovimiento;
        float movimientoX = Mathf.Cos(Time.time * velocidadMovimiento * 0.7f) * amplitudMovimiento;
        transform.localPosition = posicionInicial + new Vector3(movimientoX, movimientoY, 0);
    }

    public void MouseChange()
    {
        if (Input.GetKeyDown(KeyCode.Y))
        {
            cursorLibre = !cursorLibre;
            SetCursorState(cursorLibre);
        }
    }

    public void LiberarMouse()
    {
        cursorLibre = true;
        SetCursorState(true);
    }

    private void SetCursorState(bool libre)
    {
        if (libre)
        {
            Cursor.lockState = CursorLockMode.Confined;
            Cursor.visible = true;
        }
        else
        {
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        }
    }
}
