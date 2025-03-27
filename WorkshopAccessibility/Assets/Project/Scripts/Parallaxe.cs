using UnityEngine;

public class Parallaxe : MonoBehaviour
{
    private float _startPos;
    public GameObject mainCamera;
    public float parallaxEffect;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        _startPos = transform.position.x;
    }

    // Update is called once per frame
    void Update()
    {
        float distance = mainCamera.transform.position.x * parallaxEffect;

        transform.position = new Vector3(_startPos + distance, transform.position.y, transform.position.z);
    }
}
