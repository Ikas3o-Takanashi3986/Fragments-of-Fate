using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
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

    public Animator animator;
    public bool isJump;
    public bool IsGround;
    public bool isFalling;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponentInChildren<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        Movimiento();
        Salto();
    }

    public void Movimiento()
    {

        float movx = Input.GetAxis("Horizontal");
        float movz = Input.GetAxis("Vertical");

        Vector3 mover = transform.right * movx + transform.forward * movz;
        float Magnitud = Mathf.Clamp01(mover.magnitude);

        Controller.Move(mover * velocidad * Time.deltaTime);

        if (Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift))
        {
            Magnitud /= 0.5f;
        }

        animator.SetFloat("InputMagnitud", Magnitud, 0.05f, Time.deltaTime);

        VelocidadGravedad.y += Gravedad * Time.deltaTime;
        Controller.Move(VelocidadGravedad * Time.deltaTime);
    }

    public void Salto()
    {
        Grounded = Physics.CheckSphere(GroundCheck.position, GroundCheckDistance, GroundMask);
        
        if (Grounded && VelocidadGravedad.y < 0)
        {
            VelocidadGravedad.y = -2f;
            animator.SetBool("IsGrounded", true);
            IsGround = true;
            animator.SetBool("IsJumping", false);
            isJump = false;
        }
        else
        {
            animator.SetBool("IsGrounded", false);
            IsGround = false;

            if(isJump && VelocidadGravedad.y < 0)
            {
                animator.SetBool("IsFalling", true);
            }
        }

        if (Input.GetButtonDown("Jump"))
        {
            VelocidadGravedad.y = Mathf.Sqrt(HeightJump * -2f * Gravedad);
            animator.SetBool("IsJumping", true);
            isJump = true;
        }

        VelocidadGravedad.y += Gravedad * Time.deltaTime;
        Controller.Move(VelocidadGravedad * Time.deltaTime);
    }
       
}
