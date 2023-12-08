using System.Collections; //Importerar de nödvändiga namespaces för att använda klasser och metoder för att hantera samlingar och generiska listor.
using System.Collections.Generic; //Importerar de nödvändiga namespaces för att använda klasser och metoder för att hantera samlingar och generiska listor.
using UnityEngine; //Importerar Unity-motorns nödvändiga klasser och metoder.
using UnityEngine.SceneManagement; //Importerar klasser och metoder för scenhantering i Unity.

public class StartMenu : MonoBehaviour
{
    // Metod för att starta huvudmenyn eller startskärmen
    public void StartScreen() //En metod för att ladda huvudmenyn eller startskärmen asynkront.
    {
        // Ladda asynkront scenen med index 0 (huvudmenyn eller startskärmen)
        SceneManager.LoadSceneAsync(0);
    }

    // Metod för att avsluta applikationen
    public void Quit()
    {
        // Avsluta applikationen
        Application.Quit();
    }
}
