using UnityEngine;

namespace Meta.Interfaces
{
    public interface ICard
    {
        /// <summary>
        /// ActionPoint cost for using this card.
        /// </summary>
        public int ApCost { get; }
        
        public int CardLevel { get; }
        
        public sbyte Id { get; }
        
        /// <summary>
        /// Prefab of the cards unit.
        /// </summary>
        public GameObject CardObject { get; }
        
        public int CoolDownTime { get; }

        /// <summary>
        /// Card description
        /// </summary>
        public string Description { get; }

        public Sprite CardImage { get; }
        
        public Sprite TypeImage { get; }
        
        /// <summary>
        /// Card display name.
        /// </summary>
        public string Name { get; }

        public ICard UpgradedCard { get; }
        
        public int SellCost { get; }
        public int UpgradeCost { get; }
    }
}