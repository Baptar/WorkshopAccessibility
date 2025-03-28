using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.Audio;

public class AudioManager : MonoBehaviour
{
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
    public AudioClip star;    
    public AudioClip contactEnemy;    
    public AudioClip explosionVaisseau;
    public AudioClip laserShot;
    public AudioClip explosion;
    public AudioClip clicQTE;
    public AudioClip loose;
    public AudioClip perfect;
    public AudioClip good;
    public AudioClip miss;
    
    
    public static AudioManager instance;
    
    
    void Awake()
    {
        if (instance == null) instance = this;
    }

    private void Start()
    {
        if (background != null)
        {
            musicSource.clip = background;
            musicSource.Play();
        }
    }

    public void PlaySFX(AudioClip clip)
    {
        if (clip != null)
        sfxSource.PlayOneShot(clip);
    }

    public void PlayAmbiance(AudioClip clip)
    {
        if (clip != null)
        ambianceSource.PlayOneShot(clip);
    }
}