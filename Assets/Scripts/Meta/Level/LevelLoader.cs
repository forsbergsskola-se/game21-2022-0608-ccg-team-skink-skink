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
            FMODUnity.RuntimeManager.LoadBank(level.InternalSceneSoundBankName);
        }
    }

    public class MetaSceneLoader : MonoBehaviour
    {
        public void LoadMetaScene()
        {
            SceneManager.LoadScene("Scenes/TestScenes/MenuTest");
        }

        public void LoadMenuScene()
        {
            SceneManager.LoadScene("MenuTest");
        }
    }
}
