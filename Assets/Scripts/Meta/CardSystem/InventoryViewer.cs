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

        private Dictionary<sbyte, BasicCardViewer> cardViewers = new Dictionary<sbyte, BasicCardViewer>();
        private Stack<BasicCardViewer> hiddenCards = new Stack<BasicCardViewer>();

        void Start()
        {
            inventory.SelectedCardChanged += SetSelectedCard;
            inventory.CardAdded += AddCard;
            inventory.CardRemoved += RemoveCard;

            CreateCards();
            
            foreach (var cardList in inventory.Cards)
            {
                foreach (var card in cardList.Value)
                {
                    AddCard(card);
                }
            }
            
            Show();
        }

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
            cardViewers.Add(card.Id, basicCardViewer);

            // var cardUIObject = Instantiate(cardUIPrefab, transform);
            // cardUIObject.GetComponent<BasicCardViewer>().SetCard(card);
        }
        private void RemoveCard(ICard card){}
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

        private void Show()
        {
            Debug.Log(inventory.Cards.Count);
        }
        private void Hide(){}
    }
}
