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
            TestLoadLevel(level.InternalSceneSoundBankName, level.InternalSceneName);
        }

        public void TestLoadLevel(string soundBank, string nextLevelName)
        {
            SceneManager.LoadScene(nextLevelName);
            FMODUnity.RuntimeManager.LoadBank(soundBank);
        }
    }
}
