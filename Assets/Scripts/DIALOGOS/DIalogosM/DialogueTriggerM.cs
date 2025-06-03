using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTriggerM : MonoBehaviour
{
    public DialogueDataM dialogueDataM;
    public GameObject PanelDialogoM;


    public void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            FindObjectOfType<DialogueManagerM>().StartDialogo(dialogueDataM);
            PanelDialogoM.SetActive(true);
        }
    }

    public void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            FindObjectOfType<DialogueManagerM>().ForzarFinDialogo();
            PanelDialogoM.SetActive(false);
        }
    }
}
