namespace Meta.Interfaces
{
    public interface ICardHand
    {
        public ICard[] Cards { get; set; }
        public ICard AbilityCard { get; set; }
    }
}