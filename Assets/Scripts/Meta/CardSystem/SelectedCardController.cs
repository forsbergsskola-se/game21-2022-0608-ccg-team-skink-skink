using System;
using Meta.Interfaces;
using UnityEngine;
using Utility;

namespace Meta.CardSystem
{
    public class SelectedCardController : MonoBehaviour, ICardReceiver
    {
        private IInventory inventory;

        private void Awake()
        {
            inventory = Dependencies.Instance.Inventory;
        }

        public void ReceiveCard(ICard card)
        {
            inventory.SelectedCard = card;
        }
    }
}
