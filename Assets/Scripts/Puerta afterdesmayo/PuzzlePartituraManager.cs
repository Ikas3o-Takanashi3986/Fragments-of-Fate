using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PuzzlePartituraManager : MonoBehaviour
{
    public MonoBehaviour scriptMovimientoJugador;

    public GameObject panelPartitura;
    public RectTransform marcoSelector;
    public RectTransform[] lineas;
    public TMP_InputField[] inputFields;

    public Button botonSonido1;
    public Button botonSonido2;
    public AudioClip clipBoton1;
    public AudioClip clipBoton2;

    public AudioSource audioLineas;   
    public AudioSource audioBotones;   
    public AudioClip[] sonidosPorLinea;
    public AudioClip sonidoCorrecto;

    public PuertaPuzzle puerta;

    int lineaSeleccionada = 0;
    int botonSeleccionado = 0;  // 0: Botón 1, 1: Botón 2
    int inputIndex = 0;
    bool activo = false;
    const string codigoCorrecto = "1982";

    void Start()
    {
        panelPartitura.SetActive(false);
        botonSonido1.onClick.AddListener(() => PlayBoton(clipBoton1));
        botonSonido2.onClick.AddListener(() => PlayBoton(clipBoton2));
        UpdateBotonColors();
    }

    void Update()
    {
        if (!activo) return;

        if (Input.GetKeyDown(KeyCode.UpArrow)) ChangeLine(-1);
        if (Input.GetKeyDown(KeyCode.DownArrow)) ChangeLine(1);

        if (Input.GetKeyDown(KeyCode.LeftArrow)) SelectBoton(0);
        if (Input.GetKeyDown(KeyCode.RightArrow)) SelectBoton(1);

        if (Input.GetKeyDown(KeyCode.R)) PlayLinea();
        if (Input.GetKeyDown(KeyCode.Y)) PlayBotonActual();

        if (Input.anyKeyDown)
        {
            foreach (char c in Input.inputString)
            {
                if (char.IsDigit(c))
                {
                    WriteDigit(c.ToString());
                    break;
                }
            }
        }
    }

    public void MostrarPanel()
    {
        panelPartitura.SetActive(true);
        activo = true;
        lineaSeleccionada = 0;
        inputIndex = 0;
        ChangeLine(0);
        SelectBoton(0);

        if (scriptMovimientoJugador != null)
            scriptMovimientoJugador.enabled = false;
    }

    public void OcultarPanel()
    {
        panelPartitura.SetActive(false);
        activo = false;
        audioLineas.Stop();
        audioBotones.Stop();

        if (scriptMovimientoJugador != null)
            scriptMovimientoJugador.enabled = true;
    }

    void ChangeLine(int dir)
    {
        lineaSeleccionada = (lineaSeleccionada + dir + lineas.Length) % lineas.Length;
        marcoSelector.position = lineas[lineaSeleccionada].position;
        audioLineas.Stop();
    }

    void PlayLinea()
    {
        if (lineaSeleccionada < sonidosPorLinea.Length && sonidosPorLinea[lineaSeleccionada])
        {
            audioLineas.Stop();
            audioLineas.clip = sonidosPorLinea[lineaSeleccionada];
            audioLineas.Play();
        }
    }

    void SelectBoton(int idx)
    {
        botonSeleccionado = idx;
        audioBotones.Stop();
        UpdateBotonColors();
    }

    void PlayBotonActual()
    {
        AudioClip clip = botonSeleccionado == 0 ? clipBoton1 : clipBoton2;
        PlayBoton(clip);
    }

    void PlayBoton(AudioClip clip)
    {
        if (clip == null) return;
        audioBotones.Stop();
        audioBotones.PlayOneShot(clip);
    }

    void UpdateBotonColors()
    {
        Color normal = Color.white;
        Color rojo = Color.red;

        botonSonido1.GetComponent<Image>().color = botonSeleccionado == 0 ? rojo : normal;
        botonSonido2.GetComponent<Image>().color = botonSeleccionado == 1 ? rojo : normal;
    }

    void WriteDigit(string d)
    {
        inputFields[inputIndex].text = d;
        inputIndex = (inputIndex + 1) % inputFields.Length;
        CheckCode();
    }

    void CheckCode()
    {
        string current = "";
        foreach (var f in inputFields) current += f.text;

        if (current.Length == codigoCorrecto.Length && current == codigoCorrecto)
        {
            audioBotones.Stop();
            audioLineas.Stop();
            if (sonidoCorrecto) audioBotones.PlayOneShot(sonidoCorrecto);
            puerta.AbrirPuerta();
            OcultarPanel();
        }
    }
}
