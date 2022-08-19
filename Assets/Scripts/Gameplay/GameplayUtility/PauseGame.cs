using Meta.Interfaces;
using UnityEngine;
using Utility;

namespace Gameplay.GameplayUtility
{
    public class PauseGame : MonoBehaviour
    {
        [SerializeField] private Canvas gameCanvas;
        [SerializeField] private GameObject pauseMenu;
        [SerializeField, RequireInterface(typeof(ILevel))] Object level;


        public void TogglePause()
        {
            pauseMenu.SetActive(!pauseMenu.activeSelf);
            gameCanvas.enabled = !pauseMenu.activeSelf;
            Time.timeScale = pauseMenu.activeSelf ? 0 : 1;
        }

        public void QuitGame()
        {
            Time.timeScale = 1;
            Dependencies.Instance.LevelLoader.LoadLevel(level as ILevel);
        }
    }
}
