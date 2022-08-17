using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelMusic : MonoBehaviour
{
    [SerializeField] FMODUnity.EventReference music;
    FMOD.Studio.EventInstance musicEvInst;
    string winOrLosePath = "event:/WinLose";
    FMOD.Studio.EventInstance winLose;

    //Audio filter for when the game is paused
    public FMODUnity.EventReference pauseFilterRef;
    private FMOD.Studio.EventInstance pauseFilterInst;

    void Start()
    {
        musicEvInst = FMODUnity.RuntimeManager.CreateInstance(music);
        musicEvInst.start();
    }
    public void PauseMenuAudio()
    {
        // Debug.Log("FilterMusic");
        pauseFilterInst = FMODUnity.RuntimeManager.CreateInstance("snapshot:/PauseFilter");
        pauseFilterInst.start();
    }
    public void PauseMenuStopAudio()
    {
        pauseFilterInst.stop(FMOD.Studio.STOP_MODE.ALLOWFADEOUT);
    }
    public void PlayWinLoseSound()
    {
        winLose = FMODUnity.RuntimeManager.CreateInstance(winOrLosePath);
        winLose.start();
        winLose.release();
    }
    public void StopMusic()
    {
        musicEvInst.stop(FMOD.Studio.STOP_MODE.ALLOWFADEOUT);
        musicEvInst.release();
    }
    private void OnDestroy()
    {
        StopMusic();
    }
}
