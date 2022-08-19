using UnityEngine;

namespace Meta.GenericUIScripts
{
    public class QuitAppMenu : MonoBehaviour
    {
        [SerializeField] private GameObject menuObject;

        public void ToggleQuitMenu()
        {
            menuObject.SetActive(menuObject.activeSelf);
        }
        
        public void QuitGame()
        {
            Application.Quit();
        }
    }
}
