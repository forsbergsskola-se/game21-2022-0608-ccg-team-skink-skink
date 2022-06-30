using System.Collections;
using Meta.Interfaces;
using UnityEngine;
using UnityEngine.SceneManagement;
namespace Meta.Level
{
    public class LevelLoader : MonoBehaviour, ILevelController
    {
        public void LoadLevel(ILevel level)
        {
            StartCoroutine(Co_LoadLevel(level));
        }
        private static IEnumerator Co_LoadLevel(ILevel level)
        {
            SceneManager.LoadScene(level.InternalSceneName);
            yield return new WaitForSeconds(3);
            FMODUnity.RuntimeManager.UnloadBank("bank:/Mobile/MetaGame");
            FMODUnity.RuntimeManager.LoadBank(level.InternalSceneSoundBankName);
        }
    }
}
