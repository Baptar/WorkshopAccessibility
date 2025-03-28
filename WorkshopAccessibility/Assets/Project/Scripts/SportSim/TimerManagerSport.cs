using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;

public class TimerManager : MonoBehaviour
{
    [SerializeField] private int startMinutes = 1; 
    [SerializeField] private int startSeconds = 20; 
    [SerializeField] private TMP_Text timerText;       
    [SerializeField] private GameObject endCanvas;    
    [SerializeField] private GameObject endMenuFirstSelected;
    [SerializeField] private RhythmGameManager rhythmGameManager;

    private float timeRemaining; 
    public bool isTimerRunning = true;

    void Start()
    {
        timeRemaining = startMinutes * 60 + startSeconds;
        UpdateTimerDisplay();
    }

    void Update()
    {
        if (isTimerRunning)
        {
            timeRemaining -= Time.deltaTime;
            
            if (timeRemaining <= 0)
            {
                timeRemaining = 0;
                isTimerRunning = false;
                OnTimerEnd();
            }
            
            UpdateTimerDisplay();
        }
    }
    
    public void StartTimer()
    {
        timeRemaining = startMinutes * 60 + startSeconds;
        isTimerRunning = true;
    }
    
    public void StopTimer()
    {
        isTimerRunning = false;
    }
    
    void UpdateTimerDisplay()
    {
        int minutes = Mathf.FloorToInt(timeRemaining / 60);
        int seconds = Mathf.FloorToInt(timeRemaining % 60);
        
        timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }
    
    void OnTimerEnd()
    {
        AudioManager.instance.PlaySFX(AudioManager.instance.win);
        rhythmGameManager.gameObject.SetActive(false);
        endCanvas.SetActive(true);
        
        EventSystem.current.SetSelectedGameObject(endMenuFirstSelected);
    }
}