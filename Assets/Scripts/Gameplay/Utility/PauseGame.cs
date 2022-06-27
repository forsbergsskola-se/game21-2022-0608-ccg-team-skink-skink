using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseGame : MonoBehaviour
{
    public void Pause()
    {
         Time.timeScale = 0;
    }
    
    public void UnPause()
    {
        Time.timeScale = 1;
    }
    public void PauseMenu()
    {
        //pauseMenu.SetActive(true);
    }
    public void UnPauseMenu()
    {
        //pauseMenu.SetActive(false);
    }
    public void QuitGame()
    {
        Application.Quit();
    }
}
