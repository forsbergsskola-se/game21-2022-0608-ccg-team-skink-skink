using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Gameplay.EndGame
{
    public class GameStateTrigger : MonoBehaviour
    {
        public PauseGame pauseGame;
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
            pauseGame.Pause();
           
        }

        private void DebugLose()
        { 
           Debug.Log("You lose!"); 
           loseMessage.SetActive(true);
           pauseGame.Pause();
        }

        
        private void Start()
        {
            endGame.SubscribeWin(DebugWin);
            endGame.SubscribeLose(DebugLose);
        }
    }
}
