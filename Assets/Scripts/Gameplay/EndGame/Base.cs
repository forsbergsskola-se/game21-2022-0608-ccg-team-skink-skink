using UnityEngine;

namespace Gameplay.EndGame
{
    public class Base : MonoBehaviour
    {
        [SerializeField] private EndGameState endGame;

        public void TriggerEndGame()
        {
            if (gameObject.CompareTag("Player")) endGame.LoseInvoke();
            else endGame.WinInvoke();
        }

        private void DebugWin() => Debug.Log("You win!");
        private void DebugLose() => Debug.Log("You lose!");

        private void Start()
        {
            endGame.SubscribeWin(DebugWin);
            endGame.SubscribeLose(DebugLose);
        }
    }
}
