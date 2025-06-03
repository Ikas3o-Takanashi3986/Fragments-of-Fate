using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventosAnimacionCamaraDesmayo : MonoBehaviour
{
    public ControlCamaraDesmayo controlCamaraDesmayo;

    public void EjecutarParpadeo()
    {
        if (controlCamaraDesmayo != null)
        {
            controlCamaraDesmayo.ComenzarParpadeo();
        }
    }
}
