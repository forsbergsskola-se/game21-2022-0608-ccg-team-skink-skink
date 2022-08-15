using UnityEngine;
using Utility;

namespace Gameplay.Utility
{
    public class GameStateTrigger : MonoBehaviour
    {
        public void TriggerEndGame()
        {
            Dependencies.Instance.EndOfGameRelay.OnGameEnded(!gameObject.CompareTag("Player"));
        }
    }
}
