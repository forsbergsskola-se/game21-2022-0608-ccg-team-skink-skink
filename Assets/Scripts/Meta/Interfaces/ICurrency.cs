namespace Meta.Interfaces
{
    /// <summary>
    /// Contains the normal coins that the player has
    /// </summary>
    public interface INormalCoinCarrier
    { 
        public int Amount { get; }
    }
    /// <summary>
    /// Contains the premium coins that the player has
    /// </summary>
    public interface IPremiumCoinCarrier
    {
        public int Amount { get; }
    }
}