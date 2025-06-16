using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PickupUI : MonoBehaviour
{
    public GameObject messagePanel;

    public void ShowMessage()
    {
        if (messagePanel != null)
            messagePanel.SetActive(true);
    }

    public void HideMessage()
    {
        if (messagePanel != null)
            messagePanel.SetActive(false);
    }
}
