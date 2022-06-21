namespace Meta.Interfaces
{
    public interface ICardHand
    {
        /// <summary>
        /// Holds the current hand of cards
        /// </summary>
        public ICard[] Cards { get; }
        /// <summary>
        /// Holds the special ability card
        /// </summary>
        public ICard AbilityCard { get;}
    }
    public interface ISettableCardHand : ICardHand
    {
        public new ICard AbilityCard { set; }
    }
}