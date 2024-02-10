using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class InGameMenu : MonoBehaviour
{
    public CanvasGroup pauseMenu;
    public TextMeshProUGUI timeScaleText;

    private bool gamePaused = false;
    private float desiredTimeScale = 1f;
    
    // Start is called before the first frame update
    void Start()
    {
        
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
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
