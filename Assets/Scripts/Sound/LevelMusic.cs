using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelMusic : MonoBehaviour
{
    [SerializeField] FMODUnity.EventReference music;
    FMOD.Studio.EventInstance musicEvInst;
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
}
