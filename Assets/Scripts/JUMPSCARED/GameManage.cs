using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManage : MonoBehaviour
{
    public static GameManage Instance;

    [Header("UI Prefab")]
    public GameObject jumpscarePanelPrefab;
    public GameObject NeedKeyText;

    [Header("Opciones")]
    public float jumpscareDuration = 4f;

    [HideInInspector] public bool hasKey = false;
    [HideInInspector] public bool controlsLocked = false;

    private GameObject panelInstancia;

    public AudioSource jumpscareAudio;

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
            SceneManager.sceneLoaded += OnSceneReloaded;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void TriggerJumpscare()
    {
        if (controlsLocked) return;
        StartCoroutine(JumpscareRoutine());

        if (jumpscareAudio != null && !jumpscareAudio.isPlaying)
            jumpscareAudio.Play();
    }

    IEnumerator JumpscareRoutine()
    {
        controlsLocked = true;

        if (panelInstancia != null)
            Destroy(panelInstancia);


        Canvas canvas = FindObjectOfType<Canvas>();

        if (canvas != null && jumpscarePanelPrefab != null)
        {
           
            panelInstancia = Instantiate(jumpscarePanelPrefab, canvas.transform);
            panelInstancia.SetActive(true);
        }
        else
        {
            Debug.LogError(" No se encontró Canvas o no se asignó jumpscarePanelPrefab.");
        }

        yield return new WaitForSeconds(jumpscareDuration);

       
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    private void OnSceneReloaded(Scene scene, LoadSceneMode mode)
    {
       
        controlsLocked = false;
        hasKey = false;

       
        panelInstancia = null;
    }

    public void ShowNeedKeyMessage()
    {
        StartCoroutine(NeedKeyRoutine());
    }

    IEnumerator NeedKeyRoutine()
    {
        if (NeedKeyText != null)
            NeedKeyText.SetActive(true);

        yield return new WaitForSeconds(2f);

        if (NeedKeyText != null)
            NeedKeyText.SetActive(false);
    }

}
