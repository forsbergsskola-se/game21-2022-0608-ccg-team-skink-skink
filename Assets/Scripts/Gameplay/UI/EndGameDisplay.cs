using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Utility;

namespace Gameplay.UI
{
    public class EndGameDisplay : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI textMesh;
        [SerializeField] private Button button;

        private void Start() {
            Dependencies.Instance.EndOfGameRelay.OnWin += SetWinScreen;
            Dependencies.Instance.EndOfGameRelay.OnLose += SetLoseScreen;
        }

        private void SetLoseScreen()
        {
            ActivateComponents();
            textMesh.text = "You lose!";
            textMesh.color = Color.red;
        }

        private void SetWinScreen()
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

        void OnDestroy() {
            Dependencies.Instance.EndOfGameRelay.OnWin -= SetWinScreen;
            Dependencies.Instance.EndOfGameRelay.OnLose -= SetLoseScreen;
        }
    }
}
