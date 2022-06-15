using Meta.Interfaces;
using UnityEngine;
using UnityEngine.SceneManagement;
namespace Meta.Level
{
    public class LevelLoader : MonoBehaviour
    {
        //TODO:Get this to work with ILevel interface
        public void LoadLevel(Level level)
        {
            SceneManager.LoadScene(level.InternalSceneName);
        }
    }
}
