using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TempPauseMenu : MonoBehaviour
{
    public LevelMusic LM;
    [SerializeField] private Button pauseButton;
    [SerializeField] private Button unPauseButton;

    public void PauseGame()
    {
        pauseButton.gameObject.SetActive(false);
        unPauseButton.gameObject.SetActive(true);
        Time.timeScale = 0;
        LM.PauseMenuAudio();


    }
    public void UnPauseGame()
    {
        Time.timeScale = 1;
        pauseButton.gameObject.SetActive(true);
        unPauseButton.gameObject.SetActive(false);
        LM.PauseMenuStopAudio();

    }


}
