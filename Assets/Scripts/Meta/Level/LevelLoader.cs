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
        }
    }
}
