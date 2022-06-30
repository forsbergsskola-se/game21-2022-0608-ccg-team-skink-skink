using Gameplay.EndGame;
using UnityEngine;

namespace Gameplay.Utility
{
    public class GameStateTrigger : MonoBehaviour
    {
        [SerializeField] private EndGameStateSO endGame;
        
        public void TriggerEndGame()
        {
            if (gameObject.CompareTag("Player")) endGame.LoseInvoke();
            else endGame.WinInvoke();
        }
    }
}
