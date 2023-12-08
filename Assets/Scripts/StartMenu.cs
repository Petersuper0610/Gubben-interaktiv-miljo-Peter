using System.Collections; //Importerar de n�dv�ndiga namespaces f�r att anv�nda klasser och metoder f�r att hantera samlingar och generiska listor.
using System.Collections.Generic; //Importerar de n�dv�ndiga namespaces f�r att anv�nda klasser och metoder f�r att hantera samlingar och generiska listor.
using UnityEngine; //Importerar Unity-motorns n�dv�ndiga klasser och metoder.
using UnityEngine.SceneManagement; //Importerar klasser och metoder f�r scenhantering i Unity.

public class StartMenu : MonoBehaviour
{
    // Metod f�r att starta huvudmenyn eller startsk�rmen
    public void StartScreen() //En metod f�r att ladda huvudmenyn eller startsk�rmen asynkront.
    {
        // Ladda asynkront scenen med index 0 (huvudmenyn eller startsk�rmen)
        SceneManager.LoadSceneAsync(0);
    }

    // Metod f�r att avsluta applikationen
    public void Quit()
    {
        // Avsluta applikationen
        Application.Quit();
    }
}
