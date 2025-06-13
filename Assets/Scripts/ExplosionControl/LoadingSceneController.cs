using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LoadingSceneController : MonoBehaviour
{
    public CanvasGroup panelNegro;

    void Start()
    {
        StartCoroutine(CargarEscenaFinalNegra());
    }

    IEnumerator CargarEscenaFinalNegra()
    {
        // Asegura que el panel negro esté completamente visible
        panelNegro.alpha = 1f;

        // Espera un momento para simular fade (opcional)
        yield return new WaitForSeconds(1f);

        // Recupera el nombre de la escena guardado
        string escenaFinal = PlayerPrefs.GetString("NextScene", "");

        if (!string.IsNullOrEmpty(escenaFinal))
        {
            AsyncOperation operacion = SceneManager.LoadSceneAsync(escenaFinal);
            operacion.allowSceneActivation = false;

            // Espera a que la escena se cargue casi por completo (0.9)
            while (operacion.progress < 0.9f)
            {
                yield return null;
            }

            // Espera un segundo adicional antes de activar la escena
            yield return new WaitForSeconds(1f);

            // Activa la escena final
            operacion.allowSceneActivation = true;
        }
        else
        {
            Debug.LogError("No se encontró el nombre de la siguiente escena.");
        }
    }
}
