using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class PlayerShmup : MonoBehaviour
{
    [SerializeField] private float moveSpeed;
    [SerializeField] private GameObject projectile;
    public float projectileDelay;
    [SerializeField] private WinLimit winLimit;
    [SerializeField] private GameObject canvasLooseGO;
    [SerializeField] private GameObject looseMenuFirstSelected;
    [SerializeField] private MovingScene movingScene;
    [SerializeField] private TMP_Text scoreText;
    [SerializeField] private TMP_Text scoreText2;
    
    [Header("Life")]
    [SerializeField] private RawImage life1;
    [SerializeField] private RawImage life2;
    [SerializeField] private RawImage life3;
    
    private int life = 3;
    private float time = 0.0f;
    private Vector2 moveDirection = Vector2.zero;
    private Rigidbody2D rb;
    private Color colorLife;
    private Vector2 moveInput;
    public bool invincible = false;
    private int score = 0;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        colorLife.a = 0.3f;
        colorLife.r = 92f / 255f;
    }
    
    private void Update()
    {
        time += Time.deltaTime;
        if (time >= projectileDelay)
        {
            Instantiate(projectile, transform.position, Quaternion.identity);
            time = 0.0f;
        }
    }
    
    private void FixedUpdate()
    {
        Move();
    }

    public void addScore(int scoreToAdd)
    {
        score += scoreToAdd;
        scoreText.text = score.ToString();
        scoreText2.text = score.ToString();
    }
    
    private void Move()
    {
        moveInput = UserInput.instance.MoveInput;
        
        float currentMoveSpeed = moveSpeed;
        
        rb.linearVelocity = new Vector2(moveInput.x * currentMoveSpeed, moveInput.y * currentMoveSpeed);
    }
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Star"))
        {
            addScore(750);
            Destroy(other.gameObject);
            winLimit.star ++;
        }
    }

    public void takeDamage()
    {
        if (invincible) return;
        
        Debug.Log("Player taking damage");
        addScore(-250);
        life--;
        switch (life)
        {
            case 2:
                life3.color = colorLife;
                break;
            case 1:
                life3.color = colorLife;
                life2.color = colorLife;
                break;
            case 0:
                life3.color = colorLife;
                life2.color = colorLife;
                life1.color = colorLife;
                break;
        }
        if (life <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
        Debug.Log("player is Dead");
        canvasLooseGO.SetActive(true);
        movingScene.moving = false;
        EventSystem.current.SetSelectedGameObject(looseMenuFirstSelected);
        gameObject.SetActive(false);
    }
}
