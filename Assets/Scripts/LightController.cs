using UnityEngine;
using UnityEngine.UI;

public class LightController : MonoBehaviour
{
    public Light directionalLight; // Reference to the Directional Light
    public Button toggleButton; // Reference to the UI Button

    private void Start()
    {
        // Ensure the references are set in the Inspector
        if (directionalLight == null || toggleButton == null)
        {
            Debug.LogError("DirectionalLight or ToggleButton not assigned in the inspector!");
            return;
        }

        // Subscribe to the button's onClick event
        toggleButton.onClick.AddListener(ToggleLight);
    }

    private void ToggleLight()
    {
        // Toggle the Directional Light's state (on/off)
        directionalLight.enabled = !directionalLight.enabled;
    }
}
