using System;
using System.Linq;
using Meta.Interfaces;
using UnityEngine;

namespace Meta.CardSystem
{
    public class CardHandController : MonoBehaviour, ICardReceiver
    {
        public IInventory Inventory;
        public ISettableCardHand CardHand;

        private void Start()
        {
            Inventory.SelectedCardChanged += CheckIfCanSet;
        }

        private void SetCard(int index, ICard card)
        {
            CardHand[index] = card;
        }
        
        public void ReceiveCard(ICard card)
        {
            CardHand.SelectedCard = card;
            CheckIfCanSet(card);
        }

        private void CheckIfCanSet(ICard card)
        {
            if (Inventory.SelectedCard == null || CardHand.SelectedCard == null)
                return;
            
            if (Inventory.SelectedCard != CardHand.SelectedCard && !CardHand.Cards.Contains(Inventory.SelectedCard))
                SetCard(Array.IndexOf(CardHand.Cards, CardHand.SelectedCard), Inventory.SelectedCard);
            
            Inventory.SelectedCard = null;
            CardHand.SelectedCard = null;
        }
    }
}
