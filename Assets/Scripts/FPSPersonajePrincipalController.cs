using System.Collections;
using System.Collections.Generic;
// using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class FPSPersonajePrincipalController : MonoBehaviour
{
    public CharacterController Controller;
    public float velocidad;
    public float velocidadCorrer;

    public Vector3 VelocidadGravedad;
    public float Gravedad = -9.81f;
    public Transform GroundCheck;
    public float GroundCheckDistance = 0.4f;
    public LayerMask GroundMask;
    public bool Grounded;
    public bool Chequeo;
    public bool isDodging;
    private bool isRunning;

    public float HeightJump;

    public Animator animator;
    public bool isJump;
    public bool IsGround;
    public bool isFalling;

    public AudioSource audioSource;
    public AudioSource audioSourceRun;
    public AudioSource audioSourceCayó;
    public AudioClip caminarClip;
    public AudioClip correrClip;
    public AudioClip cayóClip;

    private bool isWalking;
    private bool haCaido = false;

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
        mover = mover.normalized;

        isRunning = (Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift)) && Magnitud > 0f;

        float velocidadActual = isRunning ? velocidadCorrer : velocidad;

        Controller.Move(mover * velocidadActual * Time.deltaTime);

        float magnitudFinal = isRunning ? 2f : Magnitud;
        animator.SetFloat("InputMagnitud", magnitudFinal, 0.05f, Time.deltaTime);

        if (Magnitud > 0.1f && !isRunning)
        {
            if (!audioSource.isPlaying)
            {
                audioSource.clip = caminarClip;
                audioSource.loop = true;
                audioSource.Play();
            }


            if (audioSourceRun.isPlaying)
                audioSourceRun.Stop();
        }

        else if (isRunning)
        {
            if (!audioSourceRun.isPlaying)
            {
                audioSourceRun.clip = correrClip;
                audioSourceRun.loop = true;
                audioSourceRun.Play();
            }


            if (audioSource.isPlaying)
                audioSource.Stop();
        }

        else
        {
            if (audioSource.isPlaying)
                audioSource.Stop();

            if (audioSourceRun.isPlaying)
                audioSourceRun.Stop();
        }


        {
            if (Input.GetKeyDown(KeyCode.Q))
            {
                animator.SetBool("IsDodging", true);
            }


            if (animator.GetCurrentAnimatorStateInfo(0).IsName("Dodging Right") &&
                animator.GetCurrentAnimatorStateInfo(0).normalizedTime >= 1.0f)
            {
                animator.SetBool("IsDodging", false);
            }
        }

        VelocidadGravedad.y += Gravedad * Time.deltaTime;
        Controller.Move(VelocidadGravedad * Time.deltaTime);
    }

    public void Salto()
    {

        bool estabaEnElAire = !Grounded;

        Grounded = Physics.CheckSphere(GroundCheck.position, GroundCheckDistance, GroundMask);
        
        if (Grounded && VelocidadGravedad.y < 0)
        {
            VelocidadGravedad.y = -2f;
            animator.SetBool("IsGrounded", true);
            IsGround = true;
            animator.SetBool("IsJumping", false);
            isJump = false;

            if (estabaEnElAire && !haCaido && cayóClip != null)
            {
                audioSourceCayó.PlayOneShot(cayóClip);
                haCaido = true;
            }
        }
        else
        {
            animator.SetBool("IsGrounded", false);
            IsGround = false;

            if(isJump && VelocidadGravedad.y < 0)
            {
                animator.SetBool("IsFalling", true);
            }

            haCaido = false;
        }

        if (Grounded && Input.GetButtonDown("Jump"))
        {
            VelocidadGravedad.y = Mathf.Sqrt(HeightJump * -2f * Gravedad);
            animator.SetBool("IsJumping", true);
            isJump = true;

            haCaido = false;
        }

        VelocidadGravedad.y += Gravedad * Time.deltaTime;
        Controller.Move(VelocidadGravedad * Time.deltaTime);
    }
       
}
