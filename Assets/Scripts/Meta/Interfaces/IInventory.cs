using System;
using System.Collections.Generic;

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
}