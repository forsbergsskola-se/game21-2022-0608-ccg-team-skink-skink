using System.Collections;
using Meta.Interfaces;
using UnityEngine;
using UnityEngine.SceneManagement;
namespace Meta.Level
{
    public class LevelLoader : MonoBehaviour, ILevelController
    {
        private string metaBank = "bank:/Mobile/MetaGame";
        private string metaSceneName = "MetaScene";
        public void LoadLevel(ILevel level)
        {
            StartCoroutine(Co_LoadLevel(level));
        }
        
        //TODO: Check if should maybe be static(bc marc said so?)
        private IEnumerator Co_LoadLevel(ILevel level)
        {
            SceneManager.LoadScene(level.InternalSceneName);
            if (level.Name == metaSceneName)
            {
                FMODUnity.RuntimeManager.LoadBank(metaBank);
                yield return new WaitForSeconds(1);
                FMODUnity.RuntimeManager.UnloadBank("bank:/Mobile/Game");
                FMODUnity.RuntimeManager.UnloadBank(level.InternalSceneSoundBankName);
            }
            else
            {
                FMODUnity.RuntimeManager.LoadBank("bank:/Mobile/Game");
                FMODUnity.RuntimeManager.LoadBank(level.InternalSceneSoundBankName);
                yield return new WaitForSeconds(1);
                FMODUnity.RuntimeManager.UnloadBank(metaBank);
            }
        }
    }
}
