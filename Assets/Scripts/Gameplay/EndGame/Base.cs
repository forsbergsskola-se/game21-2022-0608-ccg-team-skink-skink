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
    }
}
