using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class UserInput : MonoBehaviour
{
    public static UserInput instance;
    public Vector2 MoveInput { get; private set; }
    public bool JumpJustPressed { get; private set; }
    public bool JumpBeingHeld { get; private set; }
    public bool JumpReleased { get; private set; }
    public bool MenuOpenCloseInput { get; private set; }
    
    public bool LeftInput { get; private set; }
    
    public bool RightInput { get; private set; }
    
    public bool UpInput { get; private set; }
    
    public bool DownInput { get; private set; }
    
    private PlayerInput playerInput;
    
    private InputAction moveAction;
    private InputAction jumpAction;
    private InputAction menuOpenCloseAction;
    private InputAction leftAction;
    private InputAction rightAction;
    private InputAction upAction;
    private InputAction downAction;

    void Awake()
    {
        if (instance == null) instance = this;
        
        playerInput = GetComponent<PlayerInput>();

        SetupInputAction();
    }

    // Update is called once per frame
    void Update()
    {
        UpdateInputs();
    }

    private void SetupInputAction()
    {
        moveAction = playerInput.actions["Move"];
        jumpAction = playerInput.actions["Jump"];
        menuOpenCloseAction = playerInput.actions["MenuOpenClose"];
        leftAction = playerInput.actions["Left"];
        rightAction = playerInput.actions["Right"];
        upAction = playerInput.actions["Up"];
        downAction = playerInput.actions["Down"];
    }

    private void UpdateInputs()
    {
        MoveInput = moveAction.ReadValue<Vector2>();
        JumpJustPressed = jumpAction.WasPressedThisFrame();
        JumpBeingHeld = jumpAction.IsPressed();
        JumpReleased = jumpAction.WasReleasedThisFrame();
        MenuOpenCloseInput = menuOpenCloseAction.WasPressedThisFrame();
        LeftInput = leftAction.WasPressedThisFrame();
        RightInput = rightAction.WasPressedThisFrame();
        UpInput = upAction.WasPressedThisFrame();
        DownInput = downAction.WasPressedThisFrame();
    }
}
