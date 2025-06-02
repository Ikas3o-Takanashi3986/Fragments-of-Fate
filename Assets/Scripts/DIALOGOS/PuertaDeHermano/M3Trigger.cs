using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class M3Trigger : MonoBehaviour
{
    public GameObject M3Text;
    private PlayerController playerController;
    public GameObject LlaveTwo;


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
            M3Text.SetActive(true);
            LlaveTwo.SetActive(true);
        }

    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            M3Text.SetActive(false);
        }
    }


}
