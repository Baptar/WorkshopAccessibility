using TarodevController;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GameOptionsPlatformer : MonoBehaviour
{
    [Header("Slider")]
    [SerializeField] private Slider ennemySpeedSlider;
    
    [Header("Textes")]
    [SerializeField] private TMP_Text ennemySpeedText;
    
    [Header("Ref")]
    [SerializeField] private PlayerController player;
    [SerializeField] private EnnemyPlatformer[] ennemiesPlatformer;
    
    [Header("Toggle")]
    [SerializeField] private Toggle invincibleToggle;
    [SerializeField] private Toggle noEnemyToggle;
    
    private void Start()
    {
        if (PlayerPrefs.HasKey("invinciblePlatformer"))
        { 
            LoadSettings(); 
        }
        else
        {
            SetEnemySpeed();
            SetInvincible();
            SetNoEnemy();
        }
    }

    public void SetInvincible()
    {
        bool invincible = invincibleToggle.isOn;
        player.invincible = invincible;
        PlayerPrefs.SetInt("invinciblePlatformer", invincible ? 1 : 0);
    }
    
    public void SetNoEnemy()
    {
        bool noEnemy = noEnemyToggle.isOn;

        foreach (EnnemyPlatformer enemy in ennemiesPlatformer)
        {
            enemy.gameObject.SetActive(!noEnemy);
        }
        PlayerPrefs.SetInt("noEnemy", noEnemy ? 1 : 0);
    }
    
    public void SetEnemySpeed()
    {
        float speed = ennemySpeedSlider.value;

        if (ennemiesPlatformer.Length > 0)
            foreach (EnnemyPlatformer ennemy in ennemiesPlatformer)
            {
                float progression = ennemy.delayTimer / ennemy.timer;
                ennemy.delayTimer = speed;
                ennemy.timer = speed / progression;
            }
        
        PlayerPrefs.SetFloat("enemySpeedPlatformer", speed);
    }

    private void LoadSettings()
    {
        ennemySpeedSlider.value = PlayerPrefs.GetFloat("enemySpeedPlatformer");
        invincibleToggle.isOn = PlayerPrefs.GetInt("invinciblePlatformer") == 1 ? true : false;
        noEnemyToggle.isOn = PlayerPrefs.GetInt("noEnemy") == 1 ? true : false;
        
        SetEnemySpeed();
        SetInvincible();
        SetNoEnemy();
    }

    public void UpdateText()
    {
        ennemySpeedText.text = Mathf.RoundToInt(ennemySpeedSlider.value * 100) + "%";
    }
}
