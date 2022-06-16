using System.Collections.Generic;
using Meta.Interfaces;
using Meta.InventorySystem;
using UnityEngine;

namespace Utility
{
    public class PoolLoader : MonoBehaviour
    {
        [SerializeField] private PoolSO pool;
        [SerializeField] private CardHandSO playerHand;
        [SerializeField] private CardHandSO enemyHand;

        private void Awake()
        {
            var cardsToPool = new Dictionary<string, GameObject>();
            CardAdder(cardsToPool, playerHand);
            CardAdder(cardsToPool, enemyHand);
            
            Debug.Log(cardsToPool.Count);
        }

        private void CardAdder(Dictionary<string, GameObject> cardsToPool,ICardHand hand)
        {
            foreach (var card in hand.Cards)
            {
                if (!cardsToPool.ContainsKey(card.Name))
                {
                    cardsToPool.Add(card.Name, card.CardObject);
                    Debug.Log("Add: " + card.Name);
                }
            } 
        }
    }
}
