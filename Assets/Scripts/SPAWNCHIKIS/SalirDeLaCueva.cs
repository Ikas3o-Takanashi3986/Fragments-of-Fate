using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SalirDeLaCueva : MonoBehaviour
{
    public Transform puntoSalida;
    public Transform puntoRegreso;
    public float distanciaMinima = 0.5f;

    private UnityEngine.AI.NavMeshAgent agente;
    private bool estaMuerto = false;
    private bool estaRegresando = false;
    private bool estaFuera = false;

    private ChikisQueMuerden chikisScript;
    private Animator animador;

    void Start()
    {
        agente = GetComponent<UnityEngine.AI.NavMeshAgent>();
        chikisScript = GetComponent<ChikisQueMuerden>();
        animador = GetComponentInChildren<Animator>();

        agente.enabled = false;

        if (chikisScript != null)
            chikisScript.puedeSeguir = false;
    }

    void Update()
    {
        if (agente.enabled && !estaMuerto && estaRegresando && puntoRegreso != null)
        {
            float distancia = Vector3.Distance(transform.position, puntoRegreso.position);
            if (distancia <= distanciaMinima)
            {
                Ocultarse();
                estaRegresando = false;
            }
        }
    }

    public void Salir()
    {
        if (estaMuerto || estaFuera || estaRegresando) return;

        if (!agente.enabled) agente.enabled = true;
        if (chikisScript != null) chikisScript.puedeSeguir = true;

        if (puntoSalida != null)
            agente.SetDestination(puntoSalida.position);

        estaFuera = true;
        estaRegresando = false;

        if (animador != null)
            animador.SetBool("run", true);
    }

    public void Regresar()
    {
        if (estaMuerto || !estaFuera) return;

        if (!agente.enabled) agente.enabled = true;

        if (puntoRegreso != null)
        {
            agente.SetDestination(puntoRegreso.position);
            estaRegresando = true;
            estaFuera = false;

            if (chikisScript != null)
                chikisScript.puedeSeguir = false;

            if (animador != null)
                animador.SetBool("run", true);
        }
    }

    private void Ocultarse()
    {
        agente.isStopped = true;
        agente.enabled = false;

        estaRegresando = false;
        estaFuera = false;

        if (animador != null)
        {
            animador.SetBool("run", false);
            animador.SetBool("ataque", false);
        }
    }

    public void Morir()
    {
        estaMuerto = true;

        if (agente != null)
        {
            agente.isStopped = true;
            agente.enabled = false;
        }

        if (chikisScript != null)
            chikisScript.puedeSeguir = false;

        if (animador != null)
        {
            animador.SetBool("run", false);
            animador.SetBool("ataque", false);
        }
    }
}
