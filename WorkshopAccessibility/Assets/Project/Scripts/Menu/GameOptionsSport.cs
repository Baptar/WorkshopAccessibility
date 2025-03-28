using UnityEngine;
using UnityEngine.UI;

public class GameOptionsSport : MonoBehaviour
{
    [Header("Slider")]
    [SerializeField] private Slider speedQTE;
    [SerializeField] private RhythmGameManager rhythmGameManager; 
    
    private void Start()
    {
        if (PlayerPrefs.HasKey("SpeedSport"))
        { 
            LoadSettings(); 
        }
        else
        {
            SetSpeed();
        }
    }
    
    public void SetSpeed()
    {
        float speed = speedQTE.value;

        rhythmGameManager.actualNoteSpeed = speed;
        
        PlayerPrefs.SetFloat("SpeedSport", speed);
    }

    private void LoadSettings()
    {
        speedQTE.value = PlayerPrefs.GetFloat("SpeedSport");
        
        SetSpeed();
    }
}
