using System;
using Meta.CardSystem;
using Meta.Interfaces;
using UnityEngine;
using UnityEngine.Scripting;
using Object = UnityEngine.Object;
namespace Meta.Development
{
    public class TemporaryInventoryCreator : MonoBehaviour
    {
        [SerializeField] InventoryViewer inventoryViewer;
        [SerializeField] private SelectedCardController selectedCardController;
        [SerializeField] private TemporaryInventoryUserInterface temporaryInventoryUserInterface;
        [SerializeField, RequireInterface(typeof(ICard))] Object card;
        void Awake()
        {
            var inventory = new InventoryModel();
            for (int i = 0; i < 15; i++)
            {
                inventory.Add(card as ICard);    
            }

            temporaryInventoryUserInterface.Inventory = inventory;
            inventoryViewer.SetFromInventory(inventory);
            selectedCardController.Inventory = inventory;
        }
    }
}
