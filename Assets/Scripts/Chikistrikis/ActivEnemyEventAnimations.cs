using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivEnemyEventAnimations : MonoBehaviour
{
    public AudioClip PerseguirClip;
    public AudioSource Source;

    public AudioClip AtaqueClip;

    public void EnemyPerseguir()
    {
        Source.PlayOneShot(PerseguirClip);
    }

    public void EnemyAtaque()
    {
        Source.PlayOneShot(AtaqueClip);
    }
}
