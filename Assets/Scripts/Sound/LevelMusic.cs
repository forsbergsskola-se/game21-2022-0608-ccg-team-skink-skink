using System.Collections;
using System.Collections.Generic;
using FMOD.Studio;
using UnityEngine;
using Utility;

public class LevelMusic : MonoBehaviour
{
    [SerializeField] FMODUnity.EventReference music;
    FMOD.Studio.EventInstance musicEvInst;
    string winOrLosePath = "event:/WinLose";
    FMOD.Studio.EventInstance winLose;

    //Audio filter for when the game is paused
    public FMODUnity.EventReference pauseFilterRef;
    private FMOD.Studio.EventInstance pauseFilterInst;
    
    //AudienceAmbience
    private FMOD.Studio.EventInstance audienceAmbInst;
    private string audienceAmbPath = "event:/AudienceAmbience";

    void Start()
    {
        musicEvInst = FMODUnity.RuntimeManager.CreateInstance(music);
        musicEvInst.start();
        Dependencies.Instance.EndOfGameRelay.OnWin += PlayWinSound;
        Dependencies.Instance.EndOfGameRelay.OnLose += PlayLoseSound;
        audienceAmbInst = FMODUnity.RuntimeManager.CreateInstance(audienceAmbPath);
        FMODUnity.RuntimeManager.AttachInstanceToGameObject(audienceAmbInst, GetComponent<Transform>(), GetComponent<Rigidbody>());
        audienceAmbInst.start();
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
    public void PlayWinSound()
    {
        winLose = FMODUnity.RuntimeManager.CreateInstance(winOrLosePath);
        StopMusic();
        winLose.setParameterByName("Lose", 0);
        winLose.start();
        winLose.release();
    }
    public void PlayLoseSound()
    {
        winLose = FMODUnity.RuntimeManager.CreateInstance(winOrLosePath);
        StopMusic();
        winLose.setParameterByName("Lose", 1);
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
        Dependencies.Instance.EndOfGameRelay.OnWin -= PlayWinSound;
        Dependencies.Instance.EndOfGameRelay.OnLose -= PlayLoseSound;
        audienceAmbInst.stop(STOP_MODE.ALLOWFADEOUT);
        audienceAmbInst.release();

    }
}
