using System.Collections.Generic;
using Meta.Interfaces;
using UnityEngine;

namespace Utility.ObjPooling
{
    public class PoolLoader : MonoBehaviour
    {
        [Header("Unities")] 
        [SerializeField] private int amount;
        
        [Header("Dependencies")]
        [SerializeField] private Pool pool;
        [SerializeField, RequireInterface(typeof(ICardHand))] private Object enemyHand;

        private ICardHand playerHand;
        
        private void Awake()
        {
            playerHand = FindObjectOfType<Dependencies>().PlayerCardHand;
            
            var cardsToPool = new Dictionary<string, GameObject>();
            AddCHands(cardsToPool); 
            CreatePools(cardsToPool); //TODO: Make card amount adjust based on AP cost(i.e. pawn might need 20 units but juggernaut might only need 2)
        }

        private void AddCHands(Dictionary<string, GameObject> cardsToPool)
        {
            AddCards(cardsToPool, playerHand);
            AddCards(cardsToPool, enemyHand as ICardHand);
        }

        private void AddCards(Dictionary<string, GameObject> cardsToPool, ICardHand hand)
        {
            foreach (var card in hand.Cards)
            {
                if (!cardsToPool.ContainsKey(card.Name))
                    cardsToPool.Add(card.Name, card.CardObject);
            } 
        }

        private void CreatePools(Dictionary<string, GameObject> cardsToPool)
        {
            foreach (var uniqueCard in cardsToPool)
            {
                pool.CreatePool(uniqueCard.Key, uniqueCard.Value, amount);
            }
        }
    }
}
