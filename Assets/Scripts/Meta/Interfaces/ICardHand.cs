namespace Meta.Interfaces
{
    /// <summary>
    /// Interface for the deck that the player and enemy uses in gameplay
    /// </summary>
    public interface ICardHand
    {
        /// <summary>
        /// Holds the current hand of cards
        /// </summary>
        public ICard[] Cards { get; }
        /// <summary>
        /// Holds the special ability card
        /// </summary>
        public ICard AbilityCard { get; }
    }
}