using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PuzzleManager : MonoBehaviour
{
    

    public static PuzzleManager Instance;

    [Header("Puerta que se abrirá al completar el puzzle")]

    public GameObject puerta;
    public GameObject cristalSpeed;
    public GameObject cristalCURA;

    [Header("Todos los sockets")]

    public PieceSocket[] sockets;

    [Header("Temporizador")]

    public float tiempoLimite = 60f;

    private float tiempoRestante;

    public Text tiempoUI;

    public PlayerCarry playerCarry;

    private bool temporizadorActivo = false;

    void Awake()

    {

        Instance = this;

    }

    void Update()

    {

        if (temporizadorActivo)

        {

            tiempoRestante -= Time.deltaTime;

            if (tiempoUI != null)

                tiempoUI.text = Mathf.CeilToInt(tiempoRestante).ToString();

            if (tiempoRestante <= 0)

            {

                tiempoRestante = 0;

                temporizadorActivo = false;

                ReiniciarPiezas();

            }

        }

    }

    public void IniciarTemporizador()

    {

        if (!temporizadorActivo)

        {

            tiempoRestante = tiempoLimite;

            temporizadorActivo = true;

        }

    }

    public void RevisarPuzzleCompleto()

    {

        foreach (var socket in sockets)

        {

            if (!socket.IsCorrectlyPlaced())

                return;

        }

        Debug.Log("¡Puzzle completado! Puerta abierta");

        if (puerta != null)

            puerta.SetActive(false);

        temporizadorActivo = false;

        if (tiempoUI != null)

            tiempoUI.text = "";

        if (cristalSpeed != null)

            cristalSpeed.SetActive(true);

        if (cristalCURA != null)

            cristalCURA.SetActive(true);

    }

    void ReiniciarPiezas()

    {

        // Reiniciar piezas

        foreach (var socket in sockets)

        {

            socket.ResetSocket();

        }

        // Reiniciar pieza que el jugador está cargando

        if (playerCarry != null && playerCarry.IsCarrying)

        {

            playerCarry.ReturnCarriedPieceToPreviousPosition();

        }

    }

}
