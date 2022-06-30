using System;

namespace Meta.Interfaces
{
    /// <summary>
    /// Contains the normal coins that the player has
    /// </summary>
    public interface INormalCoinCarrier
    { 
        public event Action<int> ValueChanged;
        public int Amount { get; set; }
    }
    /// <summary>
    /// Contains the premium coins that the player has
    /// </summary>
    public interface IPremiumCoinCarrier
    {
        public event Action<int> ValueChanged;
        public int Amount { get; set; }
        
    }
}