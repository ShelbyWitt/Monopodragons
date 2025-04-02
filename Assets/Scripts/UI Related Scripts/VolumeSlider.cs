//VolumeSlider.cs


using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class VolumeSlider : MonoBehaviour
{
    public AudioMixer audioMixer;  // Assign your AudioMixer asset in the Inspector
    private Slider slider;

    void Start()
    {
        slider = GetComponent<Slider>();

        // Set the initial slider value based on the current AudioMixer volume
        if (audioMixer.GetFloat("MasterVolume", out float decibel))
        {
            float volume = decibel <= -80 ? 0 : Mathf.Pow(10, decibel / 20);
            slider.value = volume;
        }

        // Add a listener to update the volume when the slider value changes
        slider.onValueChanged.AddListener(SetVolume);
    }

    public void SetVolume(float volume)
    {
        // Convert slider value (0 to 1) to decibels (-80 to 0)
        float decibel = volume > 0 ? Mathf.Log10(volume) * 20 : -80;
        audioMixer.SetFloat("MasterVolume", decibel);
    }
}