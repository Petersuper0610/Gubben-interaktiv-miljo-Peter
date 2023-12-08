using UnityEngine;
using UnityEngine.UI;

public class LightController : MonoBehaviour
{
    // Referens till den riktade ljuskällan
    public Light directionalLight;

    // Referens till UI-knappen
    public Button toggleButton;

    private void Start()
    {
        // Se till att referenserna är inställda i Inspector-fönstret
        if (directionalLight == null || toggleButton == null)
        {
            // Skriv ut ett felmeddelande om referenserna inte är inställda och avsluta metoden
            Debug.LogError("DirectionalLight eller ToggleButton är inte tilldelad i Inspector-fönstret!");
            return;
        }

        // Prenumerera på knappens onClick-händelse
        toggleButton.onClick.AddListener(ToggleLight);
    }

    // Metod för att växla ljusets tillstånd (på/av)
    private void ToggleLight()
    {
        directionalLight.enabled = !directionalLight.enabled;
    }
}
