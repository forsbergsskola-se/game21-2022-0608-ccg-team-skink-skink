using System;
using System.Collections.Generic;
using Meta.Interfaces;
using Unity.VisualScripting;


namespace Meta.CardSystem
{
    public class InventoryModel : IInventory
    {
        private readonly Dictionary<sbyte,List<ICard>> internalCardList = new();
        public Dictionary<sbyte, List<ICard>> Cards => internalCardList;

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
            if (internalCardList.TryGetValue(card.Id, out List<ICard> cards))
            {
                cards.Add(card);
            }
            else
            {
                var newCardList = new List<ICard>();
                newCardList.Add(card);
                internalCardList.Add(card.Id, newCardList);
            }
            CardAdded?.Invoke(card);
        }

        public void Remove(ICard card)
        {
            if (internalCardList.TryGetValue(card.Id, out List<ICard> cards))
            {
                if (cards.Remove(card))
                {
                    if (cards.Count <= 0)
                    {
                        internalCardList.Remove(card.Id);
                        
                        // TODO: Check that this actually works! Subscribers has to be able to handle null values.
                        if (card == SelectedCard)
                            SelectedCard = null;
                    }
                    CardRemoved?.Invoke(card);
                }
            }
        }
    }
}
