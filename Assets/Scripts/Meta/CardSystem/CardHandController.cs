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
            
            // TODO:
            /* Modify card hand criteria.
             * 1. Selected card in inventory is not null
             * 2. Selected card in hand is not the same as selected card in inventory.
             * 3. Selected card in inventory is not already in another slot in the hand.
             * 4. 
             */
            
            
            
            SetCard(Array.IndexOf(CardHand.Cards, card), Inventory.SelectedCard);
            Inventory.SelectedCard = null;
        }
    }
}
