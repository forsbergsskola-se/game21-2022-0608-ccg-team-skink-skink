using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Meta.Interfaces
{
    public interface IInventory
    {
        /// <summary>
        /// Get a readonly copy of the current cards in the inventory. This list is not meant to be used to change the
        /// state. Please refer to IInventory Add and Remove!
        /// </summary>
        public IList<ICard> Cards { get; }
        
        /// <summary>
        /// Current selected card.
        /// </summary>
        public ICard SelectedCard { get; set; }

        /// <summary>
        /// Invoked when the selected card has changed.
        /// </summary>
        public event Action<ICard> SelectedCardChanged;
        public event Action<ICard> CardAdded;
        public event Action<ICard> CardRemoved;

        public void Add(ICard card);
        public void Remove(ICard card);
    }



    public interface IInventoryController
    {
        /// <summary>
        /// Creates a card. (This might end up being removed/modified)
        /// </summary>
        /// <returns></returns>
        public void AddCard(ICard card);

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
