using Meta.Interfaces;
using UnityEngine;
using UnityEngine.SceneManagement;
namespace Meta.Level
{
    //TODO: Maybe dont use MonoBehaviour if we want to load next scene when we complete a level instead of going back to map menu
    public class LevelLoader : MonoBehaviour, ILevelController
    {
        public void LoadLevel(ILevel level)
        {
            SceneManager.LoadScene(level.InternalSceneName);
        }
        //TODO:Dont destroy on load
    }
}
