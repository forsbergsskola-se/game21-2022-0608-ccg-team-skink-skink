using System;
using System.Collections.Generic;
using Meta.Interfaces;
using UnityEngine;

namespace Meta.CardSystem
{
    public class InventoryViewer : MonoBehaviour
    {
        [SerializeField] private GameObject cardUIPrefab;
        
        
        
        
        // TODO: This is temporary! We do not want this to be public in the future. A singleton set in all objects using a dependency injector would be preferred.
        public IInventory inventory;

        // TODO: This is temporary! We will want to grab the total amount of different cards from wherever all cards are stored!
        [SerializeField] private int totalDifferentCardAmount;


        private readonly Dictionary<sbyte, BasicCardViewer> cardViewers = new();
        private readonly Stack<BasicCardViewer> hiddenCards = new();
        
        

        private void AddCard(ICard card)
        {
            if (cardViewers.TryGetValue(card.Id, out BasicCardViewer basicCardViewer))
            {
                basicCardViewer.StackSize++;
                return;
            }

            basicCardViewer = hiddenCards.Pop();
            basicCardViewer.SetCard(card);
            basicCardViewer.transform.SetParent(transform);
            basicCardViewer.gameObject.SetActive(true);
            cardViewers.Add(card.Id, basicCardViewer);
        }

        private void RemoveCard(ICard card)
        {
            if (cardViewers.TryGetValue(card.Id, out BasicCardViewer basicCardViewer))
            {
                basicCardViewer.StackSize--;
                if (basicCardViewer.StackSize <= 0)
                {
                    cardViewers.Remove(card.Id);
                    hiddenCards.Push(basicCardViewer);
                    basicCardViewer.gameObject.SetActive(false);
                    basicCardViewer.transform.SetParent(transform.root);
                }
            }
        }
        
        
        private void SetSelectedCard(ICard card){}

        private void CreateCards()
        {
            for (int i = 0; i < totalDifferentCardAmount; i++)
            {
                var cardViewerObject = Instantiate(cardUIPrefab);
                var basicCardViewer = cardViewerObject.GetComponent<BasicCardViewer>();
                hiddenCards.Push(basicCardViewer);
            }
        }

        public void SetFromInventory(IInventory inventory)
        {
            inventory.SelectedCardChanged += SetSelectedCard;
            inventory.CardAdded += AddCard;
            inventory.CardRemoved += RemoveCard;

            this.inventory = inventory;

            CreateCards();

            foreach (var cardCollection in inventory.Cards)
            {
                var card = cardCollection.Value[0];
                AddCard(card);
                cardViewers[card.Id].StackSize = cardCollection.Value.Count;
            }
        }

        private void Show()
        {
            Debug.Log(inventory.Cards.Count);
        }
        
        private void Hide(){}
    }
}
