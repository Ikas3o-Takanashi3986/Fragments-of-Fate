using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyChaseWhenNotSeen : MonoBehaviour
{
    public Transform playerCamera;   
    public float moveSpeed = 3f;
    public float killDistance = 1.5f;
    public float fieldOfView = 60f; 

    CharacterController cc;
    private Animation anim;
    private bool isMoving = false;
    private bool jumpscareTriggered = false;

    public Transform visualModel;
    public float modelOffsetY = 0f;

    private AudioSource stepAudio;

    void Start()
    {
        stepAudio = GetComponent<AudioSource>();
        cc = GetComponent<CharacterController>();
        anim = GetComponentInChildren<Animation>();

        if (playerCamera == null)
        {
            Camera cam = Camera.main;
            if (cam != null)
                playerCamera = cam.transform;
        }

        anim.Play("Idle");
    }

    void Update()
    {
        LookAtPlayer();

        if (jumpscareTriggered || GameManage.Instance.controlsLocked)
        {
            SetAnimation(false);
            return;
        }

        Vector3 dirToPlayer = playerCamera.position - transform.position;
        dirToPlayer.y = 0f;
        float angle = Vector3.Angle(playerCamera.forward, -dirToPlayer);

        bool shouldMove = angle > fieldOfView;

        if (shouldMove)
        {
            Vector3 move = dirToPlayer.normalized * moveSpeed * Time.deltaTime;
            cc.Move(move);
        }

        SetAnimation(shouldMove);

        if (dirToPlayer.magnitude <= killDistance)
        {
            jumpscareTriggered = true;
            SetAnimation(false);
            GameManage.Instance.TriggerJumpscare();
        }
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
