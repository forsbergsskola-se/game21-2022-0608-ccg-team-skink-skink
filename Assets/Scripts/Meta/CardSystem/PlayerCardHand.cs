using Meta.Interfaces;

namespace Meta.CardSystem
{
    public class PlayerCardHand : ISettableCardHand
    {
        public ICard[] Cards
        {
            get;
        } = new ICard[6];
        
        public ICard AbilityCard
        {
            get;
            set;
        }
    }
}
