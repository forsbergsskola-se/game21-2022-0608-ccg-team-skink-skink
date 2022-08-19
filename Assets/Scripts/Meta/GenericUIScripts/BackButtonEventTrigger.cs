using UnityEngine;
using UnityEngine.Events;

namespace Meta.GenericUIScripts
{
    public class BackButtonEventTrigger : MonoBehaviour
    {
        public UnityEvent OnBackButtonClick;

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            { 
                OnBackButtonClick.Invoke();
            }
        }
    }
}
