using Meta.Interfaces;
using TMPro;
using UnityEngine;
using Utility;

namespace Meta.LootBox
{
    public class LootBoxAmountViewer : MonoBehaviour
    {
        private ILootBoxAmountModel lootBoxAmountModel;
        private TextMeshProUGUI textMesh;
        
        [SerializeField] private string stringBeforeValue = "";

        private void Awake()
        {
            textMesh = GetComponent<TextMeshProUGUI>();
            lootBoxAmountModel = Dependencies.Instance.LootBoxAmountModel;
        }

        private void Start()
        {
            lootBoxAmountModel.ValueChanged += UpdateAmountText;
            UpdateAmountText(lootBoxAmountModel.Amount);
        }

        private void OnDestroy()
        {
            lootBoxAmountModel.ValueChanged -= UpdateAmountText;
        }

        private void UpdateAmountText(int amount)
        {
            textMesh.text = stringBeforeValue + amount;
        }
    }
}
