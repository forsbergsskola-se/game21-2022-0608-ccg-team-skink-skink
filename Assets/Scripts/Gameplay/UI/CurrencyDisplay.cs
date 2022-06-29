using TMPro;
using UnityEngine;

namespace Gameplay.UI
{ 
    [RequireComponent(typeof(TextMeshProUGUI))]
    public class CurrencyDisplay : MonoBehaviour
    {
        private TextMeshProUGUI mesh;
        private void Awake() => mesh = GetComponent<TextMeshProUGUI>();
           
        public void UpdateDisplay(int amount) => mesh.text = $"SoftCurrency: {amount}";
    }
}
