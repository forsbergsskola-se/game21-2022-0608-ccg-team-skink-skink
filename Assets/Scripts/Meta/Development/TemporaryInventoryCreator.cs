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
        [SerializeField] FuseCards fuseCards;
        [SerializeField] private SelectedCardController selectedCardController;
        [SerializeField] private TemporaryInventoryUserInterface temporaryInventoryUserInterface;
        [SerializeField, RequireInterface(typeof(ICard))] Object[] card;
        [SerializeField] private CardHandController cardHandController;
        void Awake()
        {
            var inventory = new InventoryModel();
            var cardArray = Array.ConvertAll(card, c => c as ICard);
            
            foreach (var variablCard in cardArray)
            {
                inventory.Add(variablCard);
                inventory.Add(variablCard);
                inventory.Add(variablCard);
            }

            temporaryInventoryUserInterface.Inventory = inventory;
            inventoryViewer.SetFromInventory(inventory);
            selectedCardController.Inventory = inventory;
            fuseCards.Inventory = inventory;
            cardHandController.Inventory = inventory;
        }
    }
}
