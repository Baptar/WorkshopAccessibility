using UnityEngine;

public class MovingScene : MonoBehaviour
{
    [SerializeField] private Transform startPosition;
    [SerializeField] private Transform endPosition;
    public float duration; 
    [SerializeField] private GameObject movingScene;
    
    /*[HideInInspector] */public float gameDuration;
    [HideInInspector] public float timer = 0f;
    [HideInInspector] public bool moving = true;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        movingScene.transform.position = startPosition.position;
        gameDuration = duration;
    }

    // Update is called once per frame
    void Update()
    {
        if (moving)
        {
            timer += Time.deltaTime;
        
            movingScene.transform.position = Vector3.Lerp(startPosition.position, endPosition.position, timer / gameDuration);
        }
    }
}
