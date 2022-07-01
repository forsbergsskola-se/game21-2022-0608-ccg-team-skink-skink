using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelMusic : MonoBehaviour
{
    [SerializeField] FMODUnity.EventReference music;
    FMOD.Studio.EventInstance musicEvInst;

    //Audio filter for when the game is paused
    public FMODUnity.EventReference pauseFilterRef;
    private FMOD.Studio.EventInstance pauseFilterInst;

    void Start()
    {
        musicEvInst = FMODUnity.RuntimeManager.CreateInstance(music);
        musicEvInst.start();
    }
    public void DramaticOrchestraCue()
    {
        Debug.Log("DramaticCueSound");
        musicEvInst.setParameterByName("DramaticCue", 1);
        
    }
    public void PauseMenuAudio()
    {
        pauseFilterInst = FMODUnity.RuntimeManager.CreateInstance("snapshot:/PauseFilter");
        pauseFilterInst.start();
    }
}
