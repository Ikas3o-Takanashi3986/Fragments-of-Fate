using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class M3Doors : MonoBehaviour
{
    public GameObject[] PuertasCollider;

    public GameObject[] PuertasClosed;
    public GameObject[] PuertasOpen;

    public GameObject luzParpadeo;

    public AudioSource audioSourceDoors;
    public AudioClip sonidoDOOR;

    private Coroutine rutinaParpadeo;

    private void Start()
    {
        if (luzParpadeo != null)
            luzParpadeo.SetActive(false);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            foreach (GameObject puerta in PuertasClosed)
            {
                if (puerta != null)
                    puerta.SetActive(false);

            }


            foreach (GameObject collider in PuertasCollider)
            {
                if (collider != null)
                    collider.SetActive(false);

            }


            foreach (GameObject puerta in PuertasOpen)
            {
                if (puerta != null)
                    puerta.SetActive(true);

            }

            if (audioSourceDoors != null && sonidoDOOR != null)
            {
                audioSourceDoors.clip = sonidoDOOR;
                audioSourceDoors.Play();
            }

            if (rutinaParpadeo == null && luzParpadeo != null)
            {
                luzParpadeo.SetActive(true);
                rutinaParpadeo = StartCoroutine(ParpadeoYLuzApagar());
            }
        }
    }

    private IEnumerator ParpadeoYLuzApagar()
    {
        float tiempo = 0f;
        while (tiempo < 60f)
        {
            luzParpadeo.SetActive(!luzParpadeo.activeSelf);
            yield return new WaitForSeconds(0.5f);
            tiempo += 1f;
        }

        luzParpadeo.SetActive(false);
        rutinaParpadeo = null;
    }

}
