using System.Collections.Generic;
using Meta.Interfaces;
using Meta.InventorySystem;
using UnityEngine;

namespace Utility
{
    public class PoolLoader : MonoBehaviour
    {
        [SerializeField] private PoolSO pool;
        [SerializeField, RequireInterface(typeof(ICardHand))] private Object playerHand;
        [SerializeField, RequireInterface(typeof(ICardHand))] private Object enemyHand;

        private void Awake()
        {
            Debug.Log(playerHand);
            Debug.Log(enemyHand);
            
            var cardsToPool = new Dictionary<string, GameObject>();
            CardAdder(cardsToPool, playerHand as ICardHand);
            CardAdder(cardsToPool, enemyHand as ICardHand);
            //TODO: Make card amount adjust based on AP cost(i.e. pawn might need 20 units but juggernaut might only need 2)
            foreach (var uniqueCard in cardsToPool)
            {
                pool.CreatePool(uniqueCard.Key, uniqueCard.Value, 10);
            }
        }

        private void CardAdder(Dictionary<string, GameObject> cardsToPool, ICardHand hand)
        {
            foreach (var card in hand.Cards)
            {
                //To avoid excessive amounts of units added, only add unit of x name once
                if (!cardsToPool.ContainsKey(card.Name))
                {
                    cardsToPool.Add(card.Name, card.CardObject);
                }
            } 
        }
    }
}
