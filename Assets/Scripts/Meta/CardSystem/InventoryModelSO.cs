using System;
using System.Collections.Generic;
using Meta.Interfaces;
using UnityEngine;

namespace Meta.CardSystem
{
    [CreateAssetMenu(fileName = "InventoryModel", menuName = "ScriptableObjects/CardSystem/Development/InventoryModel")]
    public class InventoryModelSO : ScriptableObject, IInventory
    {
        // TODO: Make event fire from this when the list is changed to decouple the gridview from the controller.
        public List<ICard> Cards
        {
            get;
        } = new List<ICard>();

        
        
        private ICard selectedCard;
        
        public ICard SelectedCard
        {
            get => selectedCard;
            set
            {
                selectedCard = value;
                SelectedCardChanged?.Invoke();
            }
        }

        public event Action SelectedCardChanged;
    }
}
