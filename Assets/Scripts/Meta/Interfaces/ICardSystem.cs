using System;
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
        
        /// <summary>
        /// Current selected card.
        /// </summary>
        public ICard SelectedCard { get; set; }

        /// <summary>
        /// Invoked when the selected card has changed.
        /// </summary>
        public event Action SelectedCardChanged;
    }

    public interface ICard
    {
        /// <summary>
        /// ActionPoint cost for using this card.
        /// </summary>
        public int ApCost { get; }
        
        public int CardLevel { get; }
        
        /// <summary>
        /// Prefab of the cards unit.
        /// </summary>
        public GameObject CardObject { get; }
        
        /// <summary>
        /// Card description
        /// </summary>
        public string Description { get; }

        public Sprite Image { get; }
        
        /// <summary>
        /// Card display name.
        /// </summary>
        public string Name { get; }
    }

    public interface IInventoryController
    {
        /// <summary>
        /// Creates a card. (This might end up being removed/modified)
        /// </summary>
        /// <returns></returns>
        public ICard AddCard(ICard card);

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
