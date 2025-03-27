using TMPro;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class VolumeSettings : MonoBehaviour
{
    [Header("AudioMixer")]
    [SerializeField] private AudioMixer myMixer;
    
    [Header("Slider")]
    [SerializeField] private Slider musicSlider;
    [SerializeField] private Slider ambianceSlider;
    [SerializeField] private Slider sfxSlider;
    [SerializeField] private Slider masterSlider;
    
    [Header("Textes")]
    [SerializeField] private TMP_Text masterText;
    [SerializeField] private TMP_Text musicText;
    [SerializeField] private TMP_Text sfxText;
    [SerializeField] private TMP_Text ambianceText;


    private void Start()
    {
        if (PlayerPrefs.HasKey("musicVolume"))
        { 
            LoadVolume(); 
        }
        else
        {
            SetMusicVolume();
            SetAmbianceVolume();
            SetSFXVolume();
            SetMasterVolume();
        }
    }
    
    public void SetMusicVolume()
    {
        float volume = musicSlider.value;
        myMixer.SetFloat("Music", Mathf.Log10(volume)*20);
        PlayerPrefs.SetFloat("musicVolume", volume);
    }
    
    public void SetAmbianceVolume()
    {
        float volume = ambianceSlider.value;
        myMixer.SetFloat("Ambiance", Mathf.Log10(volume)*20);
        PlayerPrefs.SetFloat("ambianceVolume", volume);
    }
    
    public void SetSFXVolume()
    {
        float volume = sfxSlider.value;
        myMixer.SetFloat("SFX", Mathf.Log10(volume)*20);
        PlayerPrefs.SetFloat("sfxVolume", volume);
    }
    
    public void SetMasterVolume()
    {
        float volume = masterSlider.value;
        myMixer.SetFloat("Master", Mathf.Log10(volume)*20);
        PlayerPrefs.SetFloat("masterVolume", volume);
    }
    
    private void LoadVolume()
    {
        musicSlider.value = PlayerPrefs.GetFloat("musicVolume");
        ambianceSlider.value = PlayerPrefs.GetFloat("ambianceVolume");
        sfxSlider.value = PlayerPrefs.GetFloat("sfxVolume");
        masterSlider.value = PlayerPrefs.GetFloat("masterVolume");
        
        SetMusicVolume();
        SetAmbianceVolume();
        SetSFXVolume();
        SetMasterVolume();
    }

    public void UpdateText()
    {
        masterText.text = Mathf.RoundToInt(masterSlider.value * 100) + "%";
        musicText.text = Mathf.RoundToInt(musicSlider.value * 100) + "%";
        sfxText.text = Mathf.RoundToInt(sfxSlider.value * 100) + "%";
        ambianceText.text = Mathf.RoundToInt(ambianceSlider.value * 100) + "%";
    }
}
