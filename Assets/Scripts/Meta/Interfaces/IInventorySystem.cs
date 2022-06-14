using System.Collections.Generic;
using UnityEngine;

namespace Meta.Interfaces{
    public interface IInventory{
        public List <ICard> cards{ get; }
        
    }

    public interface ICard{
        public string name{ get; }
        public int cardLevel{ get; }
        public GameObject cardObject{ get; }
    }

    public interface ICardSystem{
        public ICard CreateCard();

        public ICard FuseCards(ICard[] cards);

        public void DestroyCard(ICard card);
    }
}
