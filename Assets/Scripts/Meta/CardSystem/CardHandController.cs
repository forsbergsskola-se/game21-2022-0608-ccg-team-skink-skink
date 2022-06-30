using System;
using System.Linq;
using Meta.Interfaces;
using UnityEngine;
using Utility;

namespace Meta.CardSystem
{
    public class CardHandController : MonoBehaviour, ICardReceiver
    {
        private IInventory inventory;
        private ISettableCardHand cardHand;

        private void Awake()
        {
            cardHand = Dependencies.Instance.PlayerCardHand;
            inventory = Dependencies.Instance.Inventory;
        }

        private void Start()
        {
            inventory.SelectedCardChanged += CheckIfCanSet;
            inventory.CardRemoved += CheckIfDeletedCardIsInHand;
        }

        private void SetCard(int index, ICard card)
        {
            cardHand[index] = card;
        }

        public void ReceiveCard(ICard card)
        {
            cardHand.SelectedCard = card;
            CheckIfCanSet(card);
        }

        private void CheckIfCanSet(ICard card)
        {
            if (inventory.SelectedCard == null || cardHand.SelectedCard == null)
                return;
            
            if (inventory.SelectedCard != cardHand.SelectedCard && !cardHand.Cards.Contains(inventory.SelectedCard))
                SetCard(Array.IndexOf(cardHand.Cards, cardHand.SelectedCard), inventory.SelectedCard);
            
            inventory.SelectedCard = null;
            cardHand.SelectedCard = null;
        }
        
        

        private void CheckIfDeletedCardIsInHand(ICard card)
        {
            if (inventory.Cards.ContainsKey(card.Id))
                return;
            
            if (!cardHand.Cards.Contains(card))
                return;
            
            var index = Array.IndexOf(cardHand.Cards, card);

            foreach (var values in inventory.Cards)
            {
                var inventoryCard = values.Value[0];
                if (!cardHand.Cards.Contains(inventoryCard))
                    SetCard(index, inventoryCard);
            }
        }
    }
}
