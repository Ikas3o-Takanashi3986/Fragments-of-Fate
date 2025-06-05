using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class M4FaintTrigger : MonoBehaviour
{
    public GameObject M4Text;
    public GameObject FaintTrigger;
    private PlayerController playerController;


    void Start()
    {
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        if (player != null)
        {
            playerController = player.GetComponent<PlayerController>();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            M4Text.SetActive(true);
            FaintTrigger.SetActive(true);
        }

    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            M4Text.SetActive(false);
        }
    }
}
