using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerStopFootsteps : MonoBehaviour
{
    public AudioSource playerWalkAudio;
    public AudioSource playerRunAudio;
    public AudioSource enemyFootstepAudio;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            
            if (GameManage.Instance != null && GameManage.Instance.hasKey)
            {
                if (playerWalkAudio != null && playerWalkAudio.isPlaying)
                    playerWalkAudio.Stop();

                if (playerRunAudio != null && playerRunAudio.isPlaying)
                    playerRunAudio.Stop();

                if (enemyFootstepAudio != null && enemyFootstepAudio.isPlaying)
                    enemyFootstepAudio.Stop();

                Debug.Log("Sonidos detenidos porque el jugador tiene la llave.");
            }
            else
            {
                Debug.Log("El jugador NO tiene la llave ");
            }
        }
    }
}
