using Gameplay.EndGame;
using TMPro;
using UnityEngine;

namespace Gameplay.UI
{
    [RequireComponent(typeof(TextMeshProUGUI))]
    public class EndGameDisplay : MonoBehaviour
    {
        [SerializeField] private EndGameStateSO endGame;
        private TextMeshProUGUI textMesh;

        private void Awake()
        {
            textMesh = GetComponent<TextMeshProUGUI>();
            textMesh.enabled = false;
        }

        private void Start()
        {
            endGame.SubscribeWin(() => SetWinScreen());
            endGame.SubscribeLose(() => SetLoseScreen());
        }

        public void SetLoseScreen()
        {
            textMesh.text = "You lose!";
            textMesh.color = Color.red;
            textMesh.enabled = true;
        }

        private void SetWinScreen()
        {
            textMesh.text = "You win!";
            textMesh.color = Color.yellow;
            textMesh.enabled = true;
        }
    }
}
