using UnityEngine;
using UnityEngine.UI;

public class VolumeControl : MonoBehaviour
{
    public Slider volumeSlider; // Referens till UI-slider
    public AudioSource audioSource; // Referens till ljudkälla

    private void Start()
    {
        // Se till att referenser är inställda i inspektorn
        if (volumeSlider == null || audioSource == null)
        {
            Debug.LogError("VolumeSlider eller AudioSource är inte tilldelad i inspektorn!");
            return;
        }

        // Sätt slidern till samma initiala nivå som ljudet
        volumeSlider.value = audioSource.volume;

        // testar att Ta bort från följande rad om svara på förändringar i slidervärdet
        // volumeSlider.onValueChanged.AddListener(ChangeVolume);
    }

    // Den här metoden körs när slidervärdet ändras
    public void ChangeVolume(float volume)
    {
        // Justera ljudvolymen baserat på sliderns position
        audioSource.volume = volume;
    }
}
