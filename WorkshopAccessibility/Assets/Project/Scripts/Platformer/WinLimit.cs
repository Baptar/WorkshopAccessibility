using System.Net;
using TarodevController;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class WinLimit : MonoBehaviour
{
    [SerializeField] private CameraFollowPlayer cameraFollowPlayer;
    [SerializeField] private GameObject canvasWinGO;
    [SerializeField] private GameObject looseLimit;
    [SerializeField] private GameObject winMenuFirstSelected;
    [SerializeField] private RawImage star1;
    [SerializeField] private RawImage star2;
    [SerializeField] private RawImage star3;
    [SerializeField] private Sprite starWin;
    [SerializeField] private TimeManager timerManager;
    
    private Color colorWin;
    [HideInInspector] public int star = 0;

    private void Start()
    {
        colorWin.r = 255;
        colorWin.g = 255;
        colorWin.b = 255;
        colorWin.a = 255;
    }
    private void OnEnable()
    {
        canvasWinGO.SetActive(false);
    }
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log(other.gameObject.name);
        if (other.CompareTag("Player"))
        {
            AudioManager.instance.PlaySFX(AudioManager.instance.win);
            if (timerManager) timerManager.run = false;
            other.gameObject.SetActive(false);
            GetComponent<Collider2D>().enabled = false;
            Debug.Log("player won");
            switch (star)
            {
                case 1:
                    star1.color = colorWin;
                    star1.texture = starWin.texture;
                    break;
                case 2:
                    star1.color = colorWin;
                    star1.texture = starWin.texture;
                    star2.color = colorWin;
                    star2.texture = starWin.texture;
                    break;
                case 3:
                    star1.color = colorWin;
                    star1.texture = starWin.texture;
                    star2.color = colorWin;
                    star2.texture = starWin.texture;
                    star3.color = colorWin;
                    star3.texture = starWin.texture;
                    break;
            }
            if (looseLimit) looseLimit.SetActive(false);
            if (cameraFollowPlayer) cameraFollowPlayer.followPlayer = false;
            canvasWinGO.SetActive(true);
            
            EventSystem.current.SetSelectedGameObject(winMenuFirstSelected);
        }
    }
}
