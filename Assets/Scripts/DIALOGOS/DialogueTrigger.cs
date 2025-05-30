using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTrigger : MonoBehaviour
{
    public Dialogue dialogue;
    public GameObject PanelDialogo;
    public GameObject PanelDialogoM2;

    public void TriggerDialogue()
    {
        if (!FindObjectOfType<EInteraction>().CristalRecolectado)
        {
            PanelDialogo.SetActive(true);
            FindObjectOfType<DialogueMAnager>().StartDialogo(dialogue);
        }
    }


    public void TriggerDesactivar()
    {
        PanelDialogo.SetActive(false);
    }
}
