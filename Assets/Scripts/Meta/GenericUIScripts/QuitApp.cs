using System.Collections;
using UnityEngine;

namespace Meta.GenericUIScripts
{
    public class QuitApp : MonoBehaviour
    {
        [SerializeField] private float doubleClickTime;
        
        private bool quitAllowed;
        
        public void AttemptQuit()
        {
            if (quitAllowed)
                QuitGame();
            StartCoroutine(DoubleClickTimer());
        }

        private IEnumerator DoubleClickTimer()
        {
            quitAllowed = true;
            yield return new WaitForSeconds(doubleClickTime);
            quitAllowed = false;
        }

        private void QuitGame()
        {
            Application.Quit();
        }
    }
}
