using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChikisQueMuerden : MonoBehaviour
{
    public UnityEngine.AI.NavMeshAgent Agent;
    public Transform PointerPlayer;
    public float LookRadius;
    public float LookRadiusAtaque;

    public Animator animatorEnemy;
    // Start is called before the first frame update
    void Start()
    {
        animatorEnemy = GetComponentInChildren<Animator>();

        if (PointerPlayer == null)
        {
            GameObject player = GameObject.FindGameObjectWithTag("Player");
            if (player != null)
            {
                PointerPlayer = player.transform;
            }
            else
            {
                Debug.LogError("No se encontró ningún GameObject con la etiqueta 'Player'");
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        MovNavMesh();

    }

    public void MovNavMesh()
    {
        FaceTarget();
        float distance = Vector3.Distance(PointerPlayer.position, transform.position);
        // Debug.Log(distance);

        if (distance <= LookRadius)
        {
            Agent.SetDestination(PointerPlayer.position);
            animatorEnemy.SetBool("run", true);
            Agent.speed = 3f;

            if (distance <= LookRadiusAtaque)
            {
                Agent.speed = 0f;
                animatorEnemy.SetBool("ataque", true);
            }
            else
            {
                animatorEnemy.SetBool("ataque", false);
            }
        }
        else
        {
            animatorEnemy.SetBool("run", false);
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
        Gizmos.DrawWireSphere(transform.position, LookRadiusAtaque);
    }


}