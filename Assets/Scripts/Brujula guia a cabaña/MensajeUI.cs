using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class MensajeUI : MonoBehaviour
{
    public TextMeshProUGUI mensajeTexto; 
    private float tiempoMostrando = 6f;
    private float tiempoRestante;
    private bool mostrando = false;

    void Update()
    {
        if (mostrando)
        {
            tiempoRestante -= Time.deltaTime;
            if (tiempoRestante <= 0f)
            {
                mensajeTexto.text = "";
                mostrando = false;
            }
        }
    }

    public void MostrarMensaje(string mensaje)
    {
        mensajeTexto.text = mensaje;
        tiempoRestante = tiempoMostrando;
        mostrando = true;
    }
}
