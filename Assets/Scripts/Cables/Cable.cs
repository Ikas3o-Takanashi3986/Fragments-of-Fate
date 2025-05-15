using System.Collections;
using UnityEngine;
using UnityEngine.EventSystems;

public class Cable : MonoBehaviour, IPointerClickHandler
{
    public static int cablesRestantes = 3;
    private bool Removido = false;

    public PanelFadeIn panelFadeIn;

    public void OnPointerClick(PointerEventData eventData)
    {
        if (Removido) return;

        Removido = true;
        gameObject.SetActive(false);
        cablesRestantes--;

        Debug.Log("Cable UI removido. Restantes: " + cablesRestantes);

        if (cablesRestantes <= 0 && panelFadeIn != null)
        {
            panelFadeIn.MostrarConFade();
        }
    }
}