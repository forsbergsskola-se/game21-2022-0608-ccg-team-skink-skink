using TMPro;
using UnityEngine;

namespace Gameplay.EndGame
{
    public class GameStateTrigger : MonoBehaviour
    {
        [SerializeField] private EndGameStateSO endGame;
        public GameObject winMessage;
        public GameObject loseMessage;

        public void TriggerEndGame()
        {
            if (gameObject.CompareTag("Player")) endGame.LoseInvoke();
            else endGame.WinInvoke();
        }
        
        //Todo: The methods bellow are just for debugging
        private void DebugWin()
        {
            Debug.Log("You win!");
            winMessage.SetActive(true);
            PauseGameplay();
        }

        private void DebugLose()
        { 
            Debug.Log("You lose!");
            loseMessage.SetActive(true);
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
