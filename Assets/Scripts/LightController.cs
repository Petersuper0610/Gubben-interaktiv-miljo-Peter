using UnityEngine;
using UnityEngine.UI;

public class LightController : MonoBehaviour
{
    // Referens till den riktade ljusk�llan
    public Light directionalLight;

    // Referens till UI-knappen
    public Button toggleButton;

    private void Start()
    {
        // Se till att referenserna �r inst�llda i Inspector-f�nstret
        if (directionalLight == null || toggleButton == null)
        {
            // Skriv ut ett felmeddelande om referenserna inte �r inst�llda och avsluta metoden
            Debug.LogError("DirectionalLight eller ToggleButton �r inte tilldelad i Inspector-f�nstret!");
            return;
        }

        // Prenumerera p� knappens onClick-h�ndelse
        toggleButton.onClick.AddListener(ToggleLight);
    }

    // Metod f�r att v�xla ljusets tillst�nd (p�/av)
    private void ToggleLight()
    {
        directionalLight.enabled = !directionalLight.enabled;
    }
}
