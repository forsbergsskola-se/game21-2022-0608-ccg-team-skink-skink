using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelMusic : MonoBehaviour
{
    [SerializeField] FMODUnity.EventReference music;
    FMOD.Studio.EventInstance musicEvInst;
    string winOrLosePath = "event:/WinLose";
    FMOD.Studio.EventInstance winLose;
    string audienceReactsPath = "event:/Audience/AudienceReacts";
    FMOD.Studio.EventInstance audienceReactsInstance;

    //Audio filter for when the game is paused
    public FMODUnity.EventReference pauseFilterRef;
    private FMOD.Studio.EventInstance pauseFilterInst;

    void Start()
    {
        musicEvInst = FMODUnity.RuntimeManager.CreateInstance(music);
        musicEvInst.start();
        audienceReactsInstance = FMODUnity.RuntimeManager.CreateInstance("event:/Audience/AudienceReacts");

    }
    public void DramaticOrchestraCue()
    {
        Debug.Log("DramaticCueSound");
        musicEvInst.setParameterByName("DramaticCue", 1);
    }
    public void PauseMenuAudio()
    {
        Debug.Log("FilterMusic");
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
    public void AudienceReacts()
    {
        audienceReactsInstance.start();
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
