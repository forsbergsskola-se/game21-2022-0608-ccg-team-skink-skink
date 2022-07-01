using Meta.Interfaces;
using TMPro;
using UnityEngine;
using Utility;

namespace Meta.LootBox
{
    public class LootBoxAmountViewer : MonoBehaviour
    {
        private ILootBoxAmountModel lootBoxAmountModel;

        [SerializeField] private string stringBeforeValue = "ToyBoxes: ";
        [SerializeField] private TMP_Text valueText;

        private void OnEnable()
        {
            Dependencies.Instance.LootBoxAmountModel.ValueChanged += UpdateAmountText;
            UpdateAmountText(Dependencies.Instance.LootBoxAmountModel.Amount);
        }

        private void OnDisable()
        {
            Dependencies.Instance.LootBoxAmountModel.ValueChanged -= UpdateAmountText;
        }

        private void UpdateAmountText(int amount)
        {
            valueText.text = stringBeforeValue + amount;
        }
    }
}
