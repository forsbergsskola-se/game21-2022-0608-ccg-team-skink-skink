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
            endGame.SubscribeWin(SetWinScreen);
            endGame.SubscribeLose(SetLoseScreen);
        }

        public void SetLoseScreen()
        {
            ActivateComponents();
            textMesh.text = "You lose!";
            textMesh.color = Color.red;
        }

        public void SetWinScreen()
        {
            ActivateComponents();
            textMesh.text = "You win!";
            textMesh.color = Color.yellow;
        }

        private void ActivateComponents()
        {
            button.gameObject.SetActive(true);
            textMesh.gameObject.SetActive(true);
        }
    }
}
