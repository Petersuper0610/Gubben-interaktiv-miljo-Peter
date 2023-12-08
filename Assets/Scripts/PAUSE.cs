using UnityEngine;
using UnityEngine.UI;

public class PauseMenu : MonoBehaviour
{
    // Referens till panelen du vill kunna v�xla i Inspektorn
    public GameObject pausePanel; // Tilldela din panel i Inspektorn

    // Referens till knappen du vill interagera med i Inspektorn
    public Button playButton; // Tilldela din play-knapp i Inspektorn

    void Start()
    {
        // Se till att panelen �r dold fr�n b�rjan
        if (pausePanel != null)
        {
            pausePanel.SetActive(false);
        }

        // Prenumerera p� knappens klickh�ndelse
        if (playButton != null)
        {
            playButton.onClick.AddListener(OnPlayButtonClick);
        }
        /**else
        {
            // Logga ett felmeddelande om play-knappen inte �r tilldelad i Inspektorn
            Debug.LogError("Play-knappen �r inte tilldelad. V�nligen tilldela play-knappen i Inspektorn.");
        }**/
    }

    void Update()
    {
        // Kolla efter 'Q'-tangenten f�r att v�xla pausmenyn
        if (Input.GetKeyDown(KeyCode.Q))
        {
            // Anropa metoden f�r att v�xla pausmenyn
            TogglePauseMenu();
        }
    }

    void OnPlayButtonClick()
    {
        // Triggas n�r play-knappen klickas
        // Anropa metoden f�r att v�xla pausmenyn
        TogglePauseMenu();
    }

    void TogglePauseMenu()
    {
        // Kontrollera om referensen till pauspanelen �r giltig
        if (pausePanel != null)
        {
            // V�xla synligheten av panelen
            pausePanel.SetActive(!pausePanel.activeSelf);

            // Pausa eller �teruppta spelet baserat p� panelens synlighet
            Time.timeScale = (pausePanel.activeSelf) ? 0f : 1f;

            // V�xla l�sningsl�get och synligheten f�r muspekaren baserat p� panelens synlighet
            Cursor.lockState = (pausePanel.activeSelf) ? CursorLockMode.None : CursorLockMode.Locked;
            Cursor.visible = pausePanel.activeSelf;
        }
    }

    public void Pause()
    {
        // Avaktivera pauspanelen (f�rutsatt att denna metod anv�nds externt)
        pausePanel.SetActive(false);
    }
}
