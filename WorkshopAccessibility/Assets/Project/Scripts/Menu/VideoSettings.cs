using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class SettingsManager : MonoBehaviour
{
    public TMP_Dropdown displayModeDropdown;
    public Toggle fullscreenToggle;

    void Start()
    {
        // Charger les paramètres existants
        fullscreenToggle.isOn = Screen.fullScreen;

        // Détecter et assigner le mode actuel
        displayModeDropdown.value = (int)Screen.fullScreenMode;
        
        // Ajouter des listeners
        displayModeDropdown.onValueChanged.AddListener(SetFullScreenMode);
        fullscreenToggle.onValueChanged.AddListener(ToggleFullScreen);
    }

    public void SetFullScreenMode(int modeIndex)
    {
        Debug.Log("Fullscreen mode changed to: " + modeIndex);
        Screen.fullScreenMode = (FullScreenMode)modeIndex;
        PlayerPrefs.SetInt("DisplayMode", modeIndex);
        PlayerPrefs.Save();
    }

    public void ToggleFullScreen(bool isFullScreen)
    {
        Debug.Log("isFullScreen: " + isFullScreen);
        Screen.fullScreen = isFullScreen;
        PlayerPrefs.SetInt("FullScreen", isFullScreen ? 1 : 0);
        PlayerPrefs.Save();
    }
}