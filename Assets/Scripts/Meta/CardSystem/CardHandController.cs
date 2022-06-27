using System;
using Meta.Interfaces;
using UnityEngine;

namespace Meta.CardSystem
{
    public class CardHandController : MonoBehaviour, ICardReceiver
    {
        public IInventory Inventory;
        public ISettableCardHand CardHand;
        
        private void SetCard(int index, ICard card)
        {
            CardHand[index] = card;
        }
        
        public  void ReceiveCard(ICard card)
        {
            if (Inventory.SelectedCard == null)
                return;
            SetCard(Array.IndexOf(CardHand.Cards, card), Inventory.SelectedCard);
            Inventory.SelectedCard = null;
        }
    }
}
