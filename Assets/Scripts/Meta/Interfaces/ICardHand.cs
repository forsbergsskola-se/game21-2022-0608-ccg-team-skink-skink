using System;
using UnityEngine;
namespace Meta.Interfaces
{
    public interface ICardHand
    {
        /// <summary>
        /// Holds the current hand of cards
        /// </summary>
        public ICard[] Cards { get; }
        /// <summary>
        /// Holds the special ability card
        /// </summary>
        public ICard AbilityCard { get;}
    }
    public interface ISettableCardHand : ICardHand
    {
        public event Action<int, ICard> HandChanged;
        public event Action<ICard> AbilityCardChanged;
        public event Action<ICard, int> SelectedCardChanged;
        public ICard this[int number] { get; set; }
        public new ICard AbilityCard { get; set; }
        public ICard SelectedCard { get; set; }
    }
}