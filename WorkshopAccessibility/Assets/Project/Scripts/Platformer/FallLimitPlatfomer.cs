using TarodevController;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;

public class FallLimitPlatfomer : MonoBehaviour
{
    [SerializeField] private CameraFollowPlayer cameraFollowPlayer;
    [SerializeField] private GameObject canvasLooseGO;
    [SerializeField] private GameObject looseMenuFirstSelected;

    private void OnEnable()
    {
        canvasLooseGO.SetActive(false);
    }
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log(other.gameObject.name);
        if (other.GetComponent<PlayerController>())
        {
            AudioManager.instance.PlaySFX(AudioManager.instance.loose);
            Debug.Log("player is Dead");
            cameraFollowPlayer.followPlayer = false;
            canvasLooseGO.SetActive(true);
            
            EventSystem.current.SetSelectedGameObject(looseMenuFirstSelected);
        }
    }
}
