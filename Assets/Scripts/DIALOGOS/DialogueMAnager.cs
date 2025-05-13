using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueMAnager : MonoBehaviour
{

    private Queue<string> sentences;

    public Text nameText;
    public Text dialogoText;



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

    public void StartDialogo(Dialogue dialogue)
    {
        Debug.Log("charla iniciada" + dialogue.name);
        nameText.text = dialogue.name;

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
            EndDialogue();
            return;
        }

        string sentence = sentences.Dequeue();
        Debug.Log(sentence);
        dialogoText.text = sentence;
    }

    void EndDialogue()
    {
        Debug.Log("charla finalizada");
        dialogoActivo = false;
    }
}
