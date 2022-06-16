using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelMusic : MonoBehaviour
{
    [SerializeField] List<FMODUnity.EventReference> musicLevel;
    FMOD.Studio.EventInstance musicEvInst;

    void Start()
    {
        //Select Music event reference
        musicEvInst.start();
    }

    void Update()
    {
        
    }

    void SelectMusic(int level)
    {
        musicEvInst = FMODUnity.RuntimeManager.CreateInstance(musicLevel[level]);
    }
}
