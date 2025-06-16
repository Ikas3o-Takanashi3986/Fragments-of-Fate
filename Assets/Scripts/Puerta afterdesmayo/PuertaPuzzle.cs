using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PuertaPuzzle : MonoBehaviour
{
    public Animator puertaAnimator;
    private bool abierta = false;

    public void AbrirPuerta()
    {
        if (abierta) return;

        if (puertaAnimator != null)
            puertaAnimator.SetTrigger("Abrir");
        else
            gameObject.SetActive(false); 

        abierta = true;
    }
}
