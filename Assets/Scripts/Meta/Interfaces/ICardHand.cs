namespace Meta.Interfaces
{
    public interface ICardHand
    {
        public ICard[] Cards { get; }
        public ICard AbilityCard { get; }
    }
}