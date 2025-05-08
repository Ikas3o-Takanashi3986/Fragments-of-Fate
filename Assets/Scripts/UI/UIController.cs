using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{

    public Image BarraVida;
    public float VidaActiva;
    public float vidaMax = 100f;


    void Start()
    {
        
    }


    void Update()
    {

        VidaActiva = StatsPlayer.vida;
        BarraVida.fillAmount = VidaActiva / vidaMax;

    }
}
