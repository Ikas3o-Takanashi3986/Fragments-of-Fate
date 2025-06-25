using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManage : MonoBehaviour
{
    public static GameManage Instance { get; private set; }

    public GameObject jumpscarePanel;
    public GameObject needKeyText;
    public float jumpscareDuration = 5f;

    public bool hasKey = false;
    public bool controlsLocked = false;

    void Awake()
    {
        if (Instance != null) { Destroy(gameObject); return; }
        Instance = this;
        DontDestroyOnLoad(gameObject);
    }

    public void TriggerJumpscare()
    {
        if (controlsLocked) return;
        StartCoroutine(JumpscareRoutine());
    }

    IEnumerator JumpscareRoutine()
    {
        controlsLocked = true;
        jumpscarePanel.SetActive(true);
        yield return new WaitForSeconds(jumpscareDuration);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex); 
    }

    public void ShowNeedKeyMessage()
    {
        if (needKeyText == null) return;
        StartCoroutine(NeedKeyRoutine());
    }

    IEnumerator NeedKeyRoutine()
    {
        needKeyText.SetActive(true);
        yield return new WaitForSeconds(2f);
        needKeyText.SetActive(false);
    }
}
