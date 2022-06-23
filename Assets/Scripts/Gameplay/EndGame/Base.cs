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
        
        //Todo: The methods bellow are just for debugging
        private void DebugWin()
        {
            Debug.Log("You win!");
            PauseGameplay();
        }

        private void DebugLose()
        { 
            Debug.Log("You lose!");
            PauseGameplay();
        }

        private void PauseGameplay()
        {
            Time.timeScale = 0;
        }
        private void Start()
        {
            endGame.SubscribeWin(DebugWin);
            endGame.SubscribeLose(DebugLose);
        }
    }
}
