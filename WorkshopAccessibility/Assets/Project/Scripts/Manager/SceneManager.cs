using UnityEngine;

public class SceneManager : MonoBehaviour
{
    public void OpenSportScene()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("SportSim");
    }
    
    public void OpenPlatformerScene()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("Platformer");
    }
    
    public void OpenShmupScene()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("Shmup");
    }

    public void ExitGame()
    {
        #if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
        #else
                Application.Quit();
        #endif
    }
}
