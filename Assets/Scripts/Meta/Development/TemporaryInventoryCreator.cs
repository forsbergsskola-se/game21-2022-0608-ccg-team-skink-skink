using System;
using Meta.CardSystem;
using Meta.Interfaces;
using UnityEngine;
using Utility;
using Object = UnityEngine.Object;


namespace Meta.Development
{
    public class TemporaryInventoryCreator : MonoBehaviour
    {
        [SerializeField] private InventoryViewer inventoryViewer;
        [SerializeField, RequireInterface(typeof(ICard))] private Object[] cards;
        
        
        void Awake()
        {
            var inventory = Dependencies.Instance.Inventory;
            var cardArray = Array.ConvertAll(cards, c => c as ICard);
            
            foreach (var card in cardArray)
            {
                inventory.Add(card);
                inventory.Add(card);
                inventory.Add(card);
            }
            
            inventoryViewer.SetFromInventory();
        }
    }
}
