using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    [SerializeField] GameObject pausePanel;

    bool isPaused = false;

    void Start()
    {
        if(pausePanel != null) pausePanel.SetActive(false);
    }

    void Update()
    {
        if(Keyboard.current != null && Keyboard.current.escapeKey.wasPressedThisFrame)
        {
            if(isPaused) resumeGame();
            else pauseGame();
        }
    }


    public void pauseGame()
    {
        isPaused = true;
        pausePanel.SetActive(true);
        Time.timeScale = 0f;
    }

    public void resumeGame()
    {
        isPaused = false;
        pausePanel.SetActive(false);
        Time.timeScale = 1f;
    }

    public void quitToMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(0);
    }

    
}
