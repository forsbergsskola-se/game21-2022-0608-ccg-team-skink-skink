using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Meta.Interfaces
{
    public interface IInventory
    {
        /// <summary>
        /// List of owned cards.
        /// </summary>
        public List<ICard> Cards { get; }
    }

    public interface ICard
    {
        /// <summary>
        /// Card display name.
        /// </summary>
        public string Name { get; }
        public Sprite Image { get; }
        public int CardLevel { get; }
        
        /// <summary>
        /// ActionPoint cost for using this card.
        /// </summary>
        public int ApCost { get; }
        
        /// <summary>
        /// Prefab of the cards unit.
        /// </summary>
        public GameObject CardObject { get; }
    }

    public interface ICardSystem
    {
        /// <summary>
        /// Creates a card. (This might end up being removed/modified)
        /// </summary>
        /// <returns></returns>
        public ICard CreateCard();

        /// <summary>
        /// Fuse cards together into a stronger card.
        /// </summary>
        /// <param name="cards"></param>
        /// <returns></returns>
        public ICard FuseCards(ICard[] cards);

        /// <summary>
        /// Destroys a card, removing it from the users inventory.
        /// </summary>
        /// <param name="card"></param>
        public void DestroyCard(ICard card);
    }
}
