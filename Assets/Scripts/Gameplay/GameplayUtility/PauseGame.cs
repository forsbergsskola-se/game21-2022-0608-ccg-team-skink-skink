using Meta.Interfaces;
using UnityEngine;
using Utility;

namespace Gameplay.GameplayUtility
{
    public class PauseGame : MonoBehaviour
    {
        [SerializeField] private GameObject pauseMenu;
        [SerializeField, RequireInterface(typeof(ILevel))] Object level;
    
    
        public void Pause()
        {
            pauseMenu.SetActive(true);
            Time.timeScale = 0;
        }
    
        public void UnPause()
        {
            Time.timeScale = 1;
            pauseMenu.SetActive(false);
        }

        public void QuitGame()
        {
            Dependencies.Instance.LevelLoader.LoadLevel(level as ILevel);
        }
    }
}
