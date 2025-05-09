using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerEvents : MonoBehaviour
{
    [SerializeField] private UnityEvent EntrarPlayer;
    [SerializeField] private UnityEvent ExitPlayer;

    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.tag == "Player")
        {
            EntrarPlayer.Invoke();
        }
    }

    // Update is called once per frame
    private void OnTriggerExit(Collider other)
    {
        if (other.transform.tag == "Player")
        {
            ExitPlayer.Invoke();
        }
    }
}
