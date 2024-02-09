using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InGameMenu : MonoBehaviour
{
    public CanvasGroup pauseMenu;

    private bool gamePaused = false;
    
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

        Time.timeScale = gamePaused ? 0f : 1f;
    }
}
