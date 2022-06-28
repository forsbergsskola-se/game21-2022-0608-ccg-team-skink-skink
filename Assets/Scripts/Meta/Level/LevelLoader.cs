using Meta.Interfaces;
using UnityEngine;
using UnityEngine.SceneManagement;
namespace Meta.Level
{
    public class LevelLoader : MonoBehaviour, ILevelController
    {
        public void LoadLevel(ILevel level)
        {
            SceneManager.LoadScene(level.InternalSceneName);
            FMODUnity.RuntimeManager.UnloadBank("bank:/Mobile/MetaGame");
            FMODUnity.RuntimeManager.LoadBank(level.InternalSceneSoundBankName);
        }
    }

    public class MetaSceneLoader : MonoBehaviour, ILevelController
    {
        public void LoadLevel(ILevel level)
        {
            SceneManager.LoadScene("Scenes/TestScenes/MenuTest");
            FMODUnity.RuntimeManager.UnloadBank(level.InternalSceneSoundBankName);
            FMODUnity.RuntimeManager.LoadBank("bank:/Mobile/MetaGame");
        }
    }
}
