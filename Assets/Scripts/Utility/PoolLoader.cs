using System.Collections.Generic;
using Meta.Interfaces;
using UnityEngine;

namespace Utility
{
    public class PoolLoader : MonoBehaviour
    {
        [SerializeField] private PoolSO pool;
        [SerializeField, RequireInterface(typeof(ICardHand))] private Object[] hands;
        
        private void Awake()
        {
            var cardsToPool = new Dictionary<string, GameObject>();
            AddCards(cardsToPool); 
            CreatePools(cardsToPool); //TODO: Make card amount adjust based on AP cost(i.e. pawn might need 20 units but juggernaut might only need 2)
        }

        private void CreatePools(Dictionary<string, GameObject> cardsToPool)
        {
            foreach (var uniqueCard in cardsToPool)
            {
                pool.CreatePool(uniqueCard.Key, uniqueCard.Value, 10);
            }
        }

        private void AddCards(Dictionary<string, GameObject> cardsToPool)
        {
            foreach (var hand in hands)
                AddCards(cardsToPool, hand as ICardHand);
        }

        private void AddCards(Dictionary<string, GameObject> cardsToPool, ICardHand hand)
        {
            foreach (var card in hand.Cards)
            {
                if (!cardsToPool.ContainsKey(card.Name))
                    cardsToPool.Add(card.Name, card.CardObject);
            } 
        }
    }
}
