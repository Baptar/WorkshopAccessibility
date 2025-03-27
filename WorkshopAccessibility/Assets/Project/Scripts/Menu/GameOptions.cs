using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GameOptions : MonoBehaviour
{
    [Header("Slider")]
    [SerializeField] private Slider fireSpeedSlider;
    [SerializeField] private Slider ennemySpeedSlider;
    
    [Header("Textes")]
    [SerializeField] private TMP_Text fireSpeedText;
    [SerializeField] private TMP_Text ennemySpeedText;
    
    [Header("Ref")]
    [SerializeField] private MovingScene movingScene;
    [SerializeField] private PlayerShmup player;
    [SerializeField] private EnnemyPlatformer[] ennemiesPlatformer;
    
    [Header("Toggle")]
    [SerializeField] private Toggle invincibleToggle;
    
    private void Start()
    {
        if (PlayerPrefs.HasKey("invincibleShmup"))
        { 
            LoadSettingsShmup(); 
        }
        else
        {
            SetFireSpeedShmup();
            //SetEnnemySpeedShmup();
            SetInvincibleShmup();
        }
    }

    public void SetInvincibleShmup()
    {
        bool invincible = invincibleToggle.isOn;
        player.invincible = invincible;
        PlayerPrefs.SetInt("invincibleShmup", invincible ? 1 : 0);
    }
    
    public void SetFireSpeedShmup()
    {
        float speed = fireSpeedSlider.value;
        player.projectileDelay = .5f - speed;
        PlayerPrefs.SetFloat("fireSpeedShmup", speed);
    }
    
    public void SetEnnemySpeedShmup()
    {
        float speed = ennemySpeedSlider.value;
        if (movingScene) movingScene.duration = 100 + speed;
        else
        {
            
        }
        PlayerPrefs.SetFloat("ennemySpeedShmup", speed);
    }

    private void LoadSettingsShmup()
    {
        fireSpeedSlider.value = PlayerPrefs.GetFloat("fireSpeedShmup");
        //ennemySpeedSlider.value = PlayerPrefs.GetFloat("ennemySpeedShmup");
        invincibleToggle.isOn = PlayerPrefs.GetInt("invincibleShmup") == 1 ? true : false;
        
        SetFireSpeedShmup();
       // SetEnnemySpeedShmup();
        SetInvincibleShmup();
    }

    public void UpdateTextShmup()
    {
        fireSpeedText.text = Mathf.RoundToInt(fireSpeedSlider.value * 100) + "%";
        ennemySpeedText.text = Mathf.RoundToInt(ennemySpeedSlider.value * 100) + "%";
    }
}
