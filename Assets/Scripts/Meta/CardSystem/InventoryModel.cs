using System;
using System.Collections.Generic;
using Meta.Interfaces;


namespace Meta.CardSystem
{
    public class InventoryModel : IInventory
    {
        private readonly List<ICard> internalCardList = new();
        public IList<ICard> Cards => internalCardList.AsReadOnly();

        private ICard selectedCard;

        public ICard SelectedCard
        {
            get => selectedCard;
            set
            {
                selectedCard = value;
                SelectedCardChanged?.Invoke(value);
            }
        }
        
        
        public event Action<ICard> SelectedCardChanged;
        public event Action<ICard> CardAdded;
        public event Action<ICard> CardRemoved;
        
        
        
        public void Add(ICard card)
        {
            internalCardList.Add(card);
            CardAdded?.Invoke(card);
        }

        public void Remove(ICard card)
        {
            internalCardList.Remove(card);
            CardRemoved?.Invoke(card);
        }
    }
}
