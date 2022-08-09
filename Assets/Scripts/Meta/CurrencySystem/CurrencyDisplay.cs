using Meta.Interfaces;
using TMPro;
using UnityEngine;
using Utility;


namespace Meta.CurrencySystem
{ 
    [RequireComponent(typeof(TextMeshProUGUI))]
    public class CurrencyDisplay : MonoBehaviour
    {
        private TextMeshProUGUI textMesh;
        private INormalCoinCarrier normalCoinCarrier;

        private void Awake()
        {
            normalCoinCarrier = Dependencies.Instance.NormalCoinCarrier;
            textMesh = GetComponent<TextMeshProUGUI>();
        }

        private void Start()
        {
            normalCoinCarrier.ValueChanged += UpdateDisplay;
        }

        private void UpdateDisplay(int amount)
        {
            textMesh.text = amount.ToString();
        } 
    }
}
