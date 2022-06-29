using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class LevelMusic : MonoBehaviour
{
    [SerializeField] List<FMODUnity.EventReference> musicLevel;
    //List of Fmod event references so we can drag and drop the right music to the right level.
    FMOD.Studio.EventInstance musicEvInst;

    int levelIndex; //change var to Level (not int)
    void Start()
    {
        
        //Await correct bank loading (if necessary...)
        //How do I get access to the right level? 
        SelectMusic(levelIndex);
        musicEvInst.start();
    }
    void SelectMusic(int level)
    {
        musicEvInst = FMODUnity.RuntimeManager.CreateInstance(musicLevel[levelIndex]);
    }
    void DramaticOrchestraCue()
    {
        musicEvInst.setParameterByName("DramaticCue", 1);
    }

    //returns loading state of bank
    FMOD.Studio.LOADING_STATE LoadingState(FMOD.Studio.Bank bank)
    {
        FMOD.Studio.LOADING_STATE lS;
        bank.getLoadingState(out lS);
        return lS;
    }
}
