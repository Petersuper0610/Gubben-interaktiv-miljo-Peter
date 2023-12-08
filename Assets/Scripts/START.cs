using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartGame : MonoBehaviour
{
    // Metod som startar spelet
    public void PlayGame()
    {
        // Ladda den andra scenen asynkront
        SceneManager.LoadSceneAsync(1);

        // Återställ tidsskalan till normal hastighet
        Time.timeScale = 1.0f;
    }

    // Metod som avslutar spelet
    public void Quit()
    {
        // Avsluta applikationen
        Application.Quit();
    }
}
