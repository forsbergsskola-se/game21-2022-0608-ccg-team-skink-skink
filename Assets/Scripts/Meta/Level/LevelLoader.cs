using System.Collections;
using Meta.Interfaces;
using UnityEngine;
using UnityEngine.SceneManagement;
namespace Meta.Level
{
    public class LevelLoader : MonoBehaviour, ILevelController
    {
        private string metaBank = "Mobile/MetaGame";
        private string menuBank = "Mobile/Master";

        private string gameBank = "Mobile/Game";
        //TODO: Switch to "MetaGame", once that scene has been implemented
        private string metaSceneName = "MetaLevelTest";
        private string menuSceneName = "MenuTest";
        public void LoadLevel(ILevel level)
        {
            TestLoadLevel(level.InternalSceneSoundBankName, level.InternalSceneName);
        }

        public void TestLoadLevel(string soundBank, string nextLevelName)
        {
            SceneManager.LoadScene(nextLevelName);
            FMODUnity.RuntimeManager.LoadBank(soundBank);
        }
        
        //TODO: Check if should maybe be static(bc marc said so?)
        //TODO: Remove code below, if deemed redundant
        private IEnumerator Co_LoadLevel(ILevel level)
        {
            SceneManager.LoadScene(level.InternalSceneName);
            if (level.Name == metaSceneName)
            {
                FMODUnity.RuntimeManager.LoadBank(metaBank);
                yield return new WaitForSeconds(1);
                // FMODUnity.RuntimeManager.UnloadBank(gameBank);
                // FMODUnity.RuntimeManager.UnloadBank(level.InternalSceneSoundBankName);
            }
            else if (level.Name == menuSceneName)
            {
                FMODUnity.RuntimeManager.LoadBank(menuBank);
                yield return new WaitForSeconds(1);
                // FMODUnity.RuntimeManager.UnloadBank(level.InternalSceneSoundBankName);
                // FMODUnity.RuntimeManager.UnloadBank(gameBank);
            }
            else
            {
                FMODUnity.RuntimeManager.LoadBank(gameBank);
                FMODUnity.RuntimeManager.LoadBank(level.InternalSceneSoundBankName);
                yield return new WaitForSeconds(1);
                // FMODUnity.RuntimeManager.UnloadBank(metaBank);
            }
        }
    }
}
