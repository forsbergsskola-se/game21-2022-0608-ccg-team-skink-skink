using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Meta.Interfaces
{
    public interface IInventory
    {
        public List<ICard> Cards { get; }
    }

    public interface ICard
    {
        public string Name { get; }
        public Sprite Image { get; }
        public int CardLevel { get; }
        public int ApCost { get; }
        public GameObject CardObject { get; }
    }

    public interface ICardSystem
    {
        public ICard CreateCard();

        public ICard FuseCards(ICard[] cards);

        public void DestroyCard(ICard card);
    }
}
