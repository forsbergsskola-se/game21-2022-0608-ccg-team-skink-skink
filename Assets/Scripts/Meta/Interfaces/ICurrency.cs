namespace Meta.Interfaces
{
    public interface INormalCoinCarrier
    { 
        public int Amount { get; }
    }

    public interface IPremiumCoinCarrier
    {
        public int Amount { get; }
    }
}