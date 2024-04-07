using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

/// <summary>
/// All UI in the top right corner of the screen.
/// Handles, pausing, changing time scale, restarting and quitting the game.
/// </summary>
public class InGameMenu : MonoBehaviour
{
    public CanvasGroup pauseMenu;
    public TextMeshProUGUI timeScaleText;
    public TextMeshProUGUI pauseButtonText;
    
    private bool gamePaused = true;
    private float desiredTimeScale = 1f;
    
    // Start is called before the first frame update
    void Start()
    {
        PauseGame();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PauseGame()
    {
        gamePaused = !gamePaused;

        pauseMenu.alpha = gamePaused ? 1f : 0f;
        pauseMenu.interactable = gamePaused;
        pauseMenu.blocksRaycasts = gamePaused;
        pauseMenu.GetComponent<LayoutElement>().ignoreLayout = !gamePaused;

        Time.timeScale = gamePaused ? 0f : desiredTimeScale;
        pauseButtonText.text = gamePaused ? "play" : "pause";
    }

    public void ChangeTimeScale(float value)
    {
        //dividing by two so the slider can have fractions
        desiredTimeScale = value / 2f;

        timeScaleText.text = desiredTimeScale.ToString("0.0");
        
        if (!gamePaused) Time.timeScale = desiredTimeScale;
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(1);
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
