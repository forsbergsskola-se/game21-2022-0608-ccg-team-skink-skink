using System;
using Meta.Interfaces;

namespace Meta.CardSystem
{
    public class PlayerCardHand : ISettableCardHand
    {
        public ICard[] Cards
        {
            get;
        } = new ICard[6];

        private ICard abilityCard;
        private ICard selectedCard;

        public event Action<int, ICard> HandChanged;
        public event Action<ICard> AbilityCardChanged;
        public event Action<ICard, int> SelectedCardChanged;

        public ICard this[int number]
        {
            get => Cards[number];
            set
            {
                Cards[number] = value;
                HandChanged?.Invoke(number,value);
            }
        }
        public ICard AbilityCard
        {
            get => abilityCard;
            set
            {
                abilityCard = value;
                AbilityCardChanged?.Invoke(value);
            }
        }

        public ICard SelectedCard
        {
            get => selectedCard;
            set
            {
                selectedCard = value;
                SelectedCardChanged?.Invoke(value, Array.IndexOf(Cards, value));
            }
        }
    }
}
