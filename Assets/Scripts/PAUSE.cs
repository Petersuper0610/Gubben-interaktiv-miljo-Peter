using UnityEngine;
using UnityEngine.UI;

public class PauseMenu : MonoBehaviour
{
    // Referens till panelen du vill kunna växla i Inspektorn
    public GameObject pausePanel; // Tilldela din panel i Inspektorn

    // Referens till knappen du vill interagera med i Inspektorn
    public Button playButton; // Tilldela din play-knapp i Inspektorn

    void Start()
    {
        // Se till att panelen är dold från början
        if (pausePanel != null)
        {
            pausePanel.SetActive(false);
        }

        // Prenumerera på knappens klickhändelse
        if (playButton != null)
        {
            playButton.onClick.AddListener(OnPlayButtonClick);
        }
        else
        {
            // Logga ett felmeddelande om play-knappen inte är tilldelad i Inspektorn
            Debug.LogError("Play-knappen är inte tilldelad. Vänligen tilldela play-knappen i Inspektorn.");
        }
    }

    void Update()
    {
        // Kolla efter 'Q'-tangenten för att växla pausmenyn
        if (Input.GetKeyDown(KeyCode.Q))
        {
            // Anropa metoden för att växla pausmenyn
            TogglePauseMenu();
        }
    }

    void OnPlayButtonClick()
    {
        // Triggas när play-knappen klickas
        // Anropa metoden för att växla pausmenyn
        TogglePauseMenu();
    }

    void TogglePauseMenu()
    {
        // Kontrollera om referensen till pauspanelen är giltig
        if (pausePanel != null)
        {
            // Växla synligheten av panelen
            pausePanel.SetActive(!pausePanel.activeSelf);

            // Pausa eller återuppta spelet baserat på panelens synlighet
            Time.timeScale = (pausePanel.activeSelf) ? 0f : 1f;

            // Växla låsningsläget och synligheten för muspekaren baserat på panelens synlighet
            Cursor.lockState = (pausePanel.activeSelf) ? CursorLockMode.None : CursorLockMode.Locked;
            Cursor.visible = pausePanel.activeSelf;
        }
    }

    public void Pause()
    {
        // Avaktivera pauspanelen (förutsatt att denna metod används externt)
        pausePanel.SetActive(false);
    }
}
