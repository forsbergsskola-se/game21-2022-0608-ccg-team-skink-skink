using Meta.Interfaces;
using UnityEngine;

namespace Meta.CardSystem
{
    public class SelectedCardController : MonoBehaviour, ICardReceiver
    {
        public IInventory Inventory;
    
        public void ReceiveCard(ICard card)
        {
            Inventory.SelectedCard = card;
        }
    }
}
