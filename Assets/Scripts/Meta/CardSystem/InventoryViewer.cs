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

        private void AddCard(ICard card)
        {
            var cardUIObject = Instantiate(cardUIPrefab, transform);
            cardUIObject.GetComponent<BasicCardViewer>().SetCard(card);
        }
        private void RemoveCard(ICard card){}
        private void SetSelectedCard(ICard card){}

        private void CreateCards()
        {
            foreach (var cardList in inventory.Cards)
            {
                var cardUIObject = Instantiate(cardUIPrefab, transform);
                var basicCardViewer = cardUIObject.GetComponent<BasicCardViewer>();
                basicCardViewer.SetCard(cardList.Value[0]);
                if (cardList.Value.Count > 1)
                {
                    basicCardViewer.StackSize = cardList.Value.Count;
                }
            }
        }

        private void Show()
        {
            Debug.Log(inventory.Cards.Count);
        }
        private void Hide(){}
    }
}
