using System;
using Meta.Interfaces;
using UnityEngine;

namespace Meta.CardSystem
{
    public class InventoryViewer : MonoBehaviour
    {
        public IInventory inventory;

        void Awake()
        {
            inventory.SelectedCardChanged += SetSelectedCard;
            inventory.CardAdded += AddCard;
            inventory.CardRemoved += RemoveCard;
            
            Show();
        }
        private void AddCard(ICard card){}
        private void RemoveCard(ICard card){}
        private void SetSelectedCard(ICard card){}

        private void Show()
        {
            Debug.Log(inventory.Cards.Count);
        }
        private void Hide(){}
    }
}
