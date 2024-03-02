using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class VolumeSettings : MonoBehaviour
{
    [SerializeField] private AudioMixer audioMixer = null;

    [SerializeField] private Slider audioMainSlider = null;
    [SerializeField] private Slider audioMusicSlider = null;
    [SerializeField] private Slider audioSfxSlider = null;

    private void Awake()
    {
        audioMixer.GetFloat("Master", out float mainVolume);
        audioMainSlider.value = Mathf.Exp(mainVolume / 20f);

        audioMixer.GetFloat("Music", out float musicVolume);
        audioMusicSlider.value = Mathf.Exp(musicVolume / 20);

        audioMixer.GetFloat("SFX", out float sfxVolume);
        audioSfxSlider.value = Mathf.Exp(sfxVolume / 20);
    }

    private void Start()
    {
        audioMainSlider.onValueChanged.AddListener(OnMainVolumeChanged);
        audioMusicSlider.onValueChanged.AddListener(OnMusicVolumeChanged);
        audioSfxSlider.onValueChanged.AddListener(OnSFXVolumeChanged);
    }

    private void OnMainVolumeChanged(float value)
    {
        audioMixer.SetFloat("Master", Mathf.Log(value) * 20f);
    }

    private void OnMusicVolumeChanged(float value)
    {
        audioMixer.SetFloat("Music", Mathf.Log(value) * 20f);
    }

    private void OnSFXVolumeChanged(float value)
    {
        audioMixer.SetFloat("SFX", Mathf.Log(value) * 20f);
    }

}