using System;
using System.Collections.Generic;
using Meta.Interfaces;


namespace Meta.CardSystem
{
    public class InventoryModel : IInventory
    {
        private readonly Dictionary<sbyte,List<ICard>> internalCardList = new();
        private ICard selectedCard;
        
        public Dictionary<sbyte, List<ICard>> Cards => internalCardList;

        public event Action<ICard> SelectedCardChanged;
        public event Action<ICard> CardAdded;
        public event Action<ICard> CardRemoved;

        
        
        public ICard SelectedCard
        {
            get => selectedCard;
            set
            {
                selectedCard = value;
                SelectedCardChanged?.Invoke(value);
            }
        }
        
        
        
        public void Add(ICard card)
        {
            if (internalCardList.TryGetValue(card.Id, out var cards))
            {
                cards.Add(card);
            }
            else
            {
                var newCardList = new List<ICard> {card};
                internalCardList.Add(card.Id, newCardList);
            }
            CardAdded?.Invoke(card);
        }

        public void Remove(ICard card)
        {
            if (!internalCardList.TryGetValue(card.Id, out var cards)) return;
            
            if (!cards.Remove(card)) return;
            
            if (cards.Count <= 0)
            {
                internalCardList.Remove(card.Id);
                
                if (card == SelectedCard)
                    SelectedCard = null;
            }
            CardRemoved?.Invoke(card);
        }
    }
}
