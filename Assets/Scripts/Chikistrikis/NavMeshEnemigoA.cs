using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class NavMeshEnemigoA : MonoBehaviour
{
    public NavMeshAgent Agent;
    public Transform PointerPlayer;
    public float LookRadius;
    public float LookRadiusShoot;

    public Animator enemya;

    public GameObject balaEnemigo;
    public Transform pointerbala;

    public float tiempo;
    public float tiempoRestante;
    
    void Start()
    {
        enemya = GetComponentInChildren<Animator>();
    }


    void Update()
    {
        MoveNavMesh();
    }

    public void MoveNavMesh()
    {
        float distancia = Vector3.Distance(PointerPlayer.position, transform.position);


        if (distancia <= LookRadius)
        {
            FaceTarget();
            Agent.SetDestination(PointerPlayer.position);
            enemya.SetBool("run", true);
            Agent.speed = 6f;

            if (distancia <= LookRadiusShoot)
            {

                enemya.SetBool("ataque", true);
                Agent.speed = 0f;
                GenerarBala();

            }
            else
            {

                enemya.SetBool("ataque", false);
            }
        }
        else
        {
            enemya.SetBool("run", false);
            Agent.speed = 0f;
        }

    }

    void FaceTarget()
    {
        Vector3 direction = (PointerPlayer.position - transform.position).normalized;
        Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x, 0, direction.z));
        transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, 1f);

    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, LookRadius);

        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(transform.position, LookRadiusShoot);
    }

    public void GenerarBala()
    {
        tiempoRestante = tiempoRestante - Time.deltaTime;

        if (tiempoRestante <= 0)
        {
            Instantiate(balaEnemigo, pointerbala.position, pointerbala.rotation);
            ResetearTiempo();
        }
    }
    public void ResetearTiempo()
    {
        tiempoRestante = tiempo;
    }
}
