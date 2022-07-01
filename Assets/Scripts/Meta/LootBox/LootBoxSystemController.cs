using Meta.Interfaces;
using UnityEngine;
using UnityEngine.UI;
using Utility;
using Object = UnityEngine.Object;


namespace Meta.LootBox
{
    public class LootBoxSystemController : MonoBehaviour
    {
        [SerializeField, RequireInterface(typeof(ILootBoxInventoryModel))] private Object lootBoxInventoryModel;
        [SerializeField] private Button lootBoxClickButton;
        private IInventory inventory;
        private ILootBoxAmountModel lootBoxAmountModel;
        

        private void Awake()
        {
            inventory = Dependencies.Instance.Inventory;
            lootBoxAmountModel = Dependencies.Instance.LootBoxAmountModel;
        }

        private void OnEnable()
        {
            lootBoxAmountModel.ValueChanged += ButtonControl;
            ButtonControl(lootBoxAmountModel.Amount);
        }

        private void OnDisable()
        {
            lootBoxAmountModel.ValueChanged -= ButtonControl;
        }

        public void OpenLootBox()
        {
            var cardsReceived = (lootBoxInventoryModel as ILootBoxInventoryModel).OpenLootBox();
            foreach (var card in cardsReceived)
            {
                inventory.Add(card);
            }
        }

        private void ButtonControl(int i)
        {
            lootBoxClickButton.interactable = i > 0;
        }
    }
}
