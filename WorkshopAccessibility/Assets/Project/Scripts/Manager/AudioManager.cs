using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.Audio;

public class AudioManager : MonoBehaviour
{
    /*[Header("Audio Mixer")]
    [SerializeField] private AudioMixer masterMixer;
    
    [Header("Sliders")]
    public Slider masterSlider;
    public Slider musicSlider;
    public Slider sfxSlider;

    [Header("Textes")]
    public TMP_Text masterText;
    public TMP_Text musicText;
    public TMP_Text sfxText;

    private void Start()
    {
        masterSlider.value = PlayerPrefs.HasKey("MasterVolume") ? PlayerPrefs.GetFloat("MasterVolume") : 1f;
        musicSlider.value = PlayerPrefs.HasKey("MusicVolume") ? PlayerPrefs.GetFloat("MusicVolume") : 1f;
        sfxSlider.value = PlayerPrefs.HasKey("SFXVolume") ? PlayerPrefs.GetFloat("SFXVolume") : 1f;
        
        UpdateAudio();
    }

    public void UpdateAudio()
    {
        AudioListener.volume = masterSlider.value;
        masterText.text = Mathf.RoundToInt(masterSlider.value * 100) + "%";
        musicText.text = Mathf.RoundToInt(musicSlider.value * 100) + "%";
        sfxText.text = Mathf.RoundToInt(sfxSlider.value * 100) + "%";
        
        PlayerPrefs.SetFloat("MasterVolume", masterSlider.value);
        PlayerPrefs.SetFloat("MusicVolume", musicSlider.value);
        PlayerPrefs.SetFloat("SFXVolume", sfxSlider.value);
        PlayerPrefs.Save();
    }*/
    
    [Header("Audio Source")]
    [SerializeField] private AudioSource musicSource;
    [SerializeField] private AudioSource ambianceSource;
    [SerializeField] private AudioSource sfxSource;
    
    [Header("Audio Clip")]
    public AudioClip background;
    public AudioClip receiveDamage;
    public AudioClip win;
    public AudioClip fall;
    public AudioClip groundSkate;
    
    public static AudioManager instance;
    
    
    void Awake()
    {
        if (instance == null) instance = this;
    }

    private void Start()
    {
        musicSource.clip = background;
        musicSource.Play();
    }

    public void PlaySFX(AudioClip clip)
    {
        sfxSource.PlayOneShot(clip);
    }

    public void PlayAmbiance(AudioClip clip)
    {
        ambianceSource.PlayOneShot(clip);
    }
}