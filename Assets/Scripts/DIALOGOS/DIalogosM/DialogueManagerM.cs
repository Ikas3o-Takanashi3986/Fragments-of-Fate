using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManagerM : MonoBehaviour
{
    public Text nameText;
    public Text dialogoText;

    private Queue<string> sentences;
    private bool dialogoActivo = false;

    private void Start()
    {
        sentences = new Queue<string>();
    }

    private void Update()
    {
        if (dialogoActivo && Input.GetKeyDown(KeyCode.U))
        {
            DisplayNextSentence();
        }
    }

    public void StartDialogo(DialogueDataM dialogue)
    {
        Debug.Log("Charla iniciada: " + dialogue.NameM);
        nameText.text = dialogue.NameM;

        sentences.Clear();

        foreach (string sentence in dialogue.sentences)
        {
            sentences.Enqueue(sentence);
        }

        dialogoActivo = true;
        DisplayNextSentence();
    }

    public void DisplayNextSentence()
    {
        if (sentences.Count == 0)
        {

            Debug.Log("Fin del diálogo, esperando cierre externo...");
            return;
        }

        string sentence = sentences.Dequeue();
        dialogoText.text = sentence;
    }

    public void ForzarFinDialogo()
    {
        dialogoActivo = false;
        nameText.text = "";
        dialogoText.text = "";
    }

    public bool DialogoActivo()
    {
        return dialogoActivo;
    }
}
