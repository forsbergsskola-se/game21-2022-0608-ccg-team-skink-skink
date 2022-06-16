using System.Collections.Generic;
using Meta.Interfaces;
using UnityEngine;

namespace Utility
{
    public class PoolLoader : MonoBehaviour
    {
        [SerializeField] private PoolSO pool;
        [SerializeField] private ICardHand playerHand;
        [SerializeField] private ICardHand enemyHand;

        public List<GameObject> prefabs;

        private void Awake()
        {
            var cardsToPool = new Dictionary<string, GameObject>();
            foreach (var card in playerHand.Cards)
            {
                cardsToPool.Add(card.Name, card.CardObject);
            }

            foreach (var card in enemyHand.Cards)
            {
                GameObject cardToAdd = cardsToPool[card.Name];
                if (cardToAdd == null)
                {
                    cardsToPool.Add(card.Name, card.CardObject);
                }
            }
            foreach (var prefab in prefabs )
            {
                var temp = Instantiate(prefab);
                
            }
        }
    }
}
