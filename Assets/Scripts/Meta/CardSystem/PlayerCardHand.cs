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

        public event Action<int, ICard> HandChanged;
        public event Action<ICard> AbilityCardChanged;
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
    }
}
