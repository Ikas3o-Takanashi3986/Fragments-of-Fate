using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FPSPersonajePrincipalController : MonoBehaviour
{
    public CharacterController Controller;
    public float velocidad;

    public Vector3 VelocidadGravedad;
    public float Gravedad = -9.81f;
    public Transform GroundCheck;
    public float GroundCheckDistance = 0.4f;
    public LayerMask GroundMask;
    public bool Grounded;
    public bool Chequeo;

    public float HeightJump;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Movimiento();
        Salto();
    }

    public void Movimiento()
    {
        Grounded = Physics.CheckSphere(GroundCheck.position, GroundCheckDistance, GroundMask);

        if (Grounded && VelocidadGravedad.y < 0)
        {
            VelocidadGravedad.y = -2f;
        }
        float movx = Input.GetAxis("Horizontal");
        float movz = Input.GetAxis("Vertical");

        Vector3 mover = transform.right * movx + transform.forward * movz;
        Controller.Move(mover * velocidad * Time.deltaTime);

        VelocidadGravedad.y += Gravedad * Time.deltaTime;
        Controller.Move(VelocidadGravedad * Time.deltaTime);
    }

    public void Salto()
    {
        if (Input.GetButtonDown("Jump"))
        {
            VelocidadGravedad.y = Mathf.Sqrt(HeightJump * -2f * Gravedad);
        }
    }
       
}
