using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyChaseWhenNotSeen : MonoBehaviour
{
    public Transform playerCamera;
    public float killDistance = 1.5f;
    public float fieldOfView = 60f;

    private NavMeshAgent agent;
    private Animation anim;
    private bool isMoving = false;
    private bool jumpscareTriggered = false;

    public Transform visualModel;
    public float modelOffsetY = 0f;

    private AudioSource stepAudio;

    private Vector3 startPosition;
    private Quaternion startRotation;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        anim = GetComponentInChildren<Animation>();
        stepAudio = GetComponent<AudioSource>();

        if (playerCamera == null)
        {
            Camera cam = Camera.main;
            if (cam != null)
                playerCamera = cam.transform;
        }

        
        startPosition = transform.position;
        startRotation = transform.rotation;

        anim?.Play("Idle");
    }

    void Update()
    {
        LookAtPlayer();

        if (jumpscareTriggered || GameManage.Instance.controlsLocked)
        {
            StopMovement();
            return;
        }

        Vector3 dirToPlayer = playerCamera.position - transform.position;
        dirToPlayer.y = 0f;
        float angle = Vector3.Angle(playerCamera.forward, -dirToPlayer);

        bool shouldMove = angle > fieldOfView;

        if (shouldMove)
        {
            if (agent != null)
                agent.SetDestination(playerCamera.position);
        }
        else
        {
            if (agent != null)
                agent.ResetPath();
        }

        SetAnimation(shouldMove);

        if (dirToPlayer.magnitude <= killDistance)
        {
            jumpscareTriggered = true;
            StopMovement();
            GameManage.Instance.TriggerJumpscare();
        }
    }

    public void ResetEnemyPosition()
    {
        
        if (agent != null)
        {
            agent.enabled = false;
            transform.position = startPosition;
            transform.rotation = startRotation;
            agent.enabled = true;
            agent.ResetPath();
        }

        jumpscareTriggered = false;
        SetAnimation(false);
    }

    void StopMovement()
    {
        if (agent != null)
        {
            agent.ResetPath();
            agent.isStopped = true;
        }
        SetAnimation(false);
    }

    void LookAtPlayer()
    {
        if (visualModel == null || playerCamera == null) return;

        Vector3 direction = playerCamera.position - transform.position;
        direction.y = 0f;

        if (direction.sqrMagnitude > 0.01f)
        {
            Quaternion targetRotation = Quaternion.LookRotation(direction);
            visualModel.rotation = targetRotation * Quaternion.Euler(0, modelOffsetY, 0);
        }
    }

    void SetAnimation(bool moving)
    {
        if (isMoving == moving) return;

        isMoving = moving;
        if (anim == null) return;

        if (moving)
        {
            anim.CrossFade("Run");
            if (stepAudio != null && !stepAudio.isPlaying)
                stepAudio.Play();
        }
        else
        {
            anim.CrossFade("Idle");
            if (stepAudio != null && stepAudio.isPlaying)
                stepAudio.Stop();
        }
    }
}
