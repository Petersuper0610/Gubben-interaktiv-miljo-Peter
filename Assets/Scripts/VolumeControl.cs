using UnityEngine;
using UnityEngine.UI;

public class VolumeControl : MonoBehaviour
{
    public Slider volumeSlider; // Referens till UI-slider
    public AudioSource audioSource; // Referens till ljudk�lla

    private void Start()
    {
        // Se till att referenser �r inst�llda i inspektorn
        if (volumeSlider == null || audioSource == null)
        {
            Debug.LogError("VolumeSlider eller AudioSource �r inte tilldelad i inspektorn!");
            return;
        }

        // S�tt slidern till samma initiala niv� som ljudet
        volumeSlider.value = audioSource.volume;

        // testar att Ta bort fr�n f�ljande rad om svara p� f�r�ndringar i sliderv�rdet
        // volumeSlider.onValueChanged.AddListener(ChangeVolume);
    }

    // Den h�r metoden k�rs n�r sliderv�rdet �ndras
    public void ChangeVolume(float volume)
    {
        // Justera ljudvolymen baserat p� sliderns position
        audioSource.volume = volume;
    }
}
