using System;
using Meta.Interfaces;
using UnityEngine;

namespace Meta.CardSystem
{
    public class InventoryViewer : MonoBehaviour
    {
        [SerializeField] private GameObject cardUIPrefab;
        
        public IInventory inventory;

        void Start()
        {
            inventory.SelectedCardChanged += SetSelectedCard;
            inventory.CardAdded += AddCard;
            inventory.CardRemoved += RemoveCard;

            CreateCards();
            Show();
        }
        
        private void AddCard(ICard card){}
        private void RemoveCard(ICard card){}
        private void SetSelectedCard(ICard card){}

        private void CreateCards()
        {
            foreach (var card in inventory.Cards)
            {
                Instantiate(cardUIPrefab, transform);
            }
        }

        private void Show()
        {
            Debug.Log(inventory.Cards.Count);
        }
        private void Hide(){}
    }
}
