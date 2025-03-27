using TarodevController;
using UnityEngine;
using UnityEngine.EventSystems;

public class EnnemyPlatformer : MonoBehaviour
{
    [Header("Ennemy")]
    [SerializeField] private Transform startTransform;
    [SerializeField] private Transform targetTransform;
    [SerializeField] private float delay = 5.0f;
    
    [Header("Loose")]
    [SerializeField] private CameraFollowPlayer cameraFollowPlayer;
    [SerializeField] private GameObject canvasLooseGO;
    [SerializeField] private GameObject looseMenuFirstSelected;

    private Transform start;
    private Transform target;
    [HideInInspector] public float delayTimer; 
    [HideInInspector] public float timer = 0.0f;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        start = startTransform;
        target = targetTransform;
        gameObject.transform.position = startTransform.position;
        delayTimer = delay;
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if (timer < delayTimer)
        {
            
            gameObject.transform.position = new Vector3(Mathf.Lerp(start.position.x, target.position.x, timer / delayTimer), gameObject.transform.position.y, gameObject.transform.position.z);
        }
        else
        {
            (start, target) = (target, start);
            gameObject.transform.localScale = new Vector3(-gameObject.transform.localScale.x, gameObject.transform.localScale.y, gameObject.transform.localScale.z);
            timer = 0.0f;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent<PlayerController>(out PlayerController player))
        {
            if (player.invincible) return;
            
            collision.gameObject.SetActive(false);
            cameraFollowPlayer.followPlayer = false;
            canvasLooseGO.SetActive(true);
            
            EventSystem.current.SetSelectedGameObject(looseMenuFirstSelected);
        }
    }
}
