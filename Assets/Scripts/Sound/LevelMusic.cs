using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelMusic : MonoBehaviour
{
    [SerializeField] FMODUnity.EventReference musicLevel;
    FMOD.Studio.EventInstance musicEvInst;
    void Start()
    {
        //Select Music event reference
        musicEvInst.start();
    }
    void DramaticOrchestraCue()
    {
        musicEvInst.setParameterByName("DramaticCue", 1);
    }
}
