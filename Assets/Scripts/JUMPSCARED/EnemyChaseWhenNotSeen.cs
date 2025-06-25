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
    bool jumpscareTriggered = false;

    void Start() => cc = GetComponent<CharacterController>();

    void Update()
    {
        if (jumpscareTriggered || GameManage.Instance.controlsLocked) return;

        Vector3 dirToPlayer = playerCamera.position - transform.position;
        float angle = Vector3.Angle(playerCamera.forward, -dirToPlayer);

       
        if (angle > fieldOfView)
        {
            Vector3 move = dirToPlayer.normalized * moveSpeed * Time.deltaTime;
            cc.Move(move);
        }

        
        if (dirToPlayer.magnitude <= killDistance)
        {
            jumpscareTriggered = true;
            GameManage.Instance.TriggerJumpscare();
        }
    }
}
