using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneControler : MonoBehaviour
{

    public GameObject PanelPausa;

    void Start()
    {
        
    }


    void Update()
    {
        
    }

    public void MenuPausa()
    {
        PanelPausa.SetActive(true);
        Time.timeScale = 0;

    }

    public void Escena1()
    {
        SceneManager.LoadScene(1);

    }

    public void Resume()
    {
        PanelPausa.SetActive(false);
        Time.timeScale = 1;

    }

    public void ToMenu()
    {
        SceneManager.LoadScene(0);
        Time.timeScale = 1;
    }

}
