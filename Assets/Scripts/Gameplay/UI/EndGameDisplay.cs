using Gameplay.EndGame;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Gameplay.UI
{
    public class EndGameDisplay : MonoBehaviour
    {
        [SerializeField] private EndGameStateSO endGame;
        [SerializeField] private TextMeshProUGUI textMesh;
        [SerializeField] private Button button;

        private void Start()
        {
            endGame.SubscribeWin(() => SetWinScreen());
            endGame.SubscribeLose(() => SetLoseScreen());
        }

        public void SetLoseScreen()
        {
            textMesh.gameObject.SetActive(true);
            textMesh.text = "You lose!";
            textMesh.color = Color.red;

            button.gameObject.SetActive(true);

        }

        private void SetWinScreen()
        {
            textMesh.gameObject.SetActive(true);
            textMesh.text = "You win!";
            textMesh.color = Color.yellow;
            
            button.gameObject.SetActive(true);
        }
    }
}
