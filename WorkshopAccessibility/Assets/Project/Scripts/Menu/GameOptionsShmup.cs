using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GameOptionsShmup : MonoBehaviour
{
    [Header("Slider")]
    [SerializeField] private Slider fireSpeedSlider;
    [SerializeField] private Slider enemySpeedSlider;
    
    [Header("Ref")]
    [SerializeField] private MovingScene movingScene;
    [SerializeField] private PlayerShmup player;
    
    [Header("Toggle")]
    [SerializeField] private Toggle invincibleToggle;
    
    private IEnumerator Start()
    {
        yield return new WaitForSeconds(0.1f);
        if (PlayerPrefs.HasKey("invincibleShmup"))
        { 
            LoadSettingsShmup(); 
        }
        else
        {
            SetFireSpeedShmup();
            SetEnemySpeedShmup();
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
        player.projectileDelay = speed;
        PlayerPrefs.SetFloat("fireSpeedShmup", speed);
    }
    
    public void SetEnemySpeedShmup()
    {
        float speed = enemySpeedSlider.value;
        
        float progression = movingScene.gameDuration / movingScene.timer;
        movingScene.gameDuration = speed;
        movingScene.timer = speed / progression;
        
        PlayerPrefs.SetFloat("enemySpeedShmup", speed);
    }

    private void LoadSettingsShmup()
    {
        fireSpeedSlider.value = PlayerPrefs.GetFloat("fireSpeedShmup");
        enemySpeedSlider.value = PlayerPrefs.GetFloat("enemySpeedShmup");
        invincibleToggle.isOn = PlayerPrefs.GetInt("invincibleShmup") == 1 ? true : false;
        
        SetFireSpeedShmup();
        SetEnemySpeedShmup();
        SetInvincibleShmup();
    }
}
