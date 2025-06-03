using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]

public class DialogueDataM
{
    public string NameM;

    [TextArea(3, 10)]
    public string[] sentences;
}
