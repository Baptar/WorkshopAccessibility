using TarodevController;
using UnityEngine;
using UnityEngine.EventSystems;
public class MenuManager : MonoBehaviour
{
    [Header("Menu Objects")]
    [SerializeField] private GameObject mainMenuCanvasGO;
    [SerializeField] private GameObject settingsMenuCanvasGO;
    [SerializeField] private GameObject keyboardsettingsMenuCanvasGO;
    [SerializeField] private GameObject gamepadSettingsMenuCanvasGO;
    [SerializeField] private GameObject videoSettingsMenuCanvasGO;
    [SerializeField] private GameObject audioSettingsMenuCanvasGO;
    [SerializeField] private GameObject controlsSettingsMenuCanvasGO;
    [SerializeField] private GameObject gameSettingsMenuCanvasGO;
    
    [Header("Player Script to Deactivate on Pause")]
    [SerializeField] private PlayerController playerPlatformer;
    [SerializeField] private PlayerShmup playerShmup;
    [SerializeField] private PlayerSport playerSport;
    
    [Header("First Selected Options")]
    [SerializeField] private GameObject mainMenuFirstSelected;
    [SerializeField] private GameObject settingsMenuFirstSelected;
    [SerializeField] private GameObject controlsMenuFirstSelected;
    [SerializeField] private GameObject keyboardMenuFirstSelected;
    [SerializeField] private GameObject gamepadMenuFirstSelected;
    [SerializeField] private GameObject videoMenuFirstSelected;
    [SerializeField] private GameObject audioMenuFirstSelected;
    [SerializeField] private GameObject gameMenuFirstSelected;
    
    private bool isPaused;
    private bool canBack = true;

    public void SetCanBack(bool canBack)
    {
        this.canBack = canBack;
    }
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        mainMenuCanvasGO.SetActive(false);
        settingsMenuCanvasGO.SetActive(false);
        keyboardsettingsMenuCanvasGO.SetActive(false);
        gamepadSettingsMenuCanvasGO.SetActive(false);
        videoSettingsMenuCanvasGO.SetActive(false);
        audioSettingsMenuCanvasGO.SetActive(false);
        controlsSettingsMenuCanvasGO.SetActive(false);
        gameSettingsMenuCanvasGO.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (UserInput.instance.MenuOpenCloseInput)
        {
            if (!isPaused)
            {
                Pause();
            }
            else if (canBack)
            {
                UnPause();
            }
        }
    }

    #region Pause/Unpause Functions

    public void Pause()
    {
        isPaused = true;
        Time.timeScale = 0f;

        if (playerPlatformer != null) playerPlatformer.enabled = false;
        if (playerShmup != null) playerShmup.enabled = false;
        if (playerSport != null) playerSport.enabled = false;
        
        OpenMainMenu();
    }

    public void UnPause()
    {
        isPaused = false;
        Time.timeScale = 1f;

        if (playerPlatformer != null) playerPlatformer.enabled = true;
        if (playerShmup != null) playerShmup.enabled = true;
        if (playerSport != null) playerSport.enabled = true;
        
        CloseAllMenus();
    }

    #endregion
    
    #region Canvas Activations/Deactivation Functions

    // Main Menu
    private void OpenMainMenu()
    {
        mainMenuCanvasGO.SetActive(true);
        settingsMenuCanvasGO.SetActive(false);
        
        EventSystem.current.SetSelectedGameObject(mainMenuFirstSelected);
    }

    // Settings
    private void OpenSettingsMenuHandle()
    {
        settingsMenuCanvasGO.SetActive(true);
        mainMenuCanvasGO.SetActive(false);
        videoSettingsMenuCanvasGO.SetActive(false);
        audioSettingsMenuCanvasGO.SetActive(false);
        controlsSettingsMenuCanvasGO.SetActive(false);
        gameSettingsMenuCanvasGO.SetActive(false);
        
        EventSystem.current.SetSelectedGameObject(settingsMenuFirstSelected);
    }
    
    // Video
    private void OpenVideoSettingsMenuHandle()
    {
        videoSettingsMenuCanvasGO.SetActive(true);
        settingsMenuCanvasGO.SetActive(false);
        
        EventSystem.current.SetSelectedGameObject(videoMenuFirstSelected);
    }
    
    // Audio
    private void OpenAudioSettingsMenuHandle()
    {
        audioSettingsMenuCanvasGO.SetActive(true);
        settingsMenuCanvasGO.SetActive(false);
        
        EventSystem.current.SetSelectedGameObject(audioMenuFirstSelected);
    }
    
    // Controls
    private void OpenControlsMenuHandle()
    {
        controlsSettingsMenuCanvasGO.SetActive(true);
        settingsMenuCanvasGO.SetActive(false);
        gamepadSettingsMenuCanvasGO.SetActive(false);
        keyboardsettingsMenuCanvasGO.SetActive(false);
        
        EventSystem.current.SetSelectedGameObject(controlsMenuFirstSelected);
    }
    
    // Game
    private void OpenGameMenuHandle()
    {
        gameSettingsMenuCanvasGO.SetActive(true);
        settingsMenuCanvasGO.SetActive(false);
        
        EventSystem.current.SetSelectedGameObject(gameMenuFirstSelected);
    }
    
    // Keyboard
    private void OpenKeyboardSettingsMenuHandle()
    {
        keyboardsettingsMenuCanvasGO.SetActive(true);
        controlsSettingsMenuCanvasGO.SetActive(false);
        
        EventSystem.current.SetSelectedGameObject(keyboardMenuFirstSelected);
    }

    // Gamepad
    private void OpenGamepadSettingsMenuHandle()
    {
        gamepadSettingsMenuCanvasGO.SetActive(true);
        controlsSettingsMenuCanvasGO.SetActive(false);
        
        EventSystem.current.SetSelectedGameObject(gamepadMenuFirstSelected);
    }

    // Close
    private void CloseAllMenus()
    {
        mainMenuCanvasGO.SetActive(false);
        settingsMenuCanvasGO.SetActive(false);
        keyboardsettingsMenuCanvasGO.SetActive(false);
        gamepadSettingsMenuCanvasGO.SetActive(false);
        videoSettingsMenuCanvasGO.SetActive(false);
        audioSettingsMenuCanvasGO.SetActive(false);
        controlsSettingsMenuCanvasGO.SetActive(false);
        gameSettingsMenuCanvasGO.SetActive(false);
        
        EventSystem.current.SetSelectedGameObject(null);
    }
    
    #endregion
    
    #region Main Menu Button Actions

    public void OnSettingsBackPress()
    {
        OpenMainMenu();
    }
    
    public void OpenSettingsPress()
    {
        OpenSettingsMenuHandle();
    }

    public void OnResumePress()
    {
        UnPause();
    }
    
    #endregion
    
    #region Settings Menu Button Actions
    
    public void OnSettingsInputBackPress()
    {
        OpenSettingsMenuHandle();
    }
    
    public void OnSettingsVideoPress()
    {
        OpenVideoSettingsMenuHandle();
    }
    
    public void OnSettingsAudioPress()
    {
        OpenAudioSettingsMenuHandle();
    }

    public void OnControlsPress()
    {
        OpenControlsMenuHandle();
    }

    public void OnGamePress()
    {
        OpenGameMenuHandle();
    }
    
    #endregion
    
    #region Controls Menu Button Actions
    
    public void OnControlsBackPress()
    {
        OpenControlsMenuHandle();
    }
    
    public void OnSettingsKeyboardPress()
    {
        OpenKeyboardSettingsMenuHandle();
    }

    public void OnSettingsGamepadPress()
    {
        OpenGamepadSettingsMenuHandle();
    }
    
    #endregion
}
