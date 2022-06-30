using System;
using System.Collections.Generic;
using Meta.Interfaces;
using UnityEngine;
using Object = UnityEngine.Object;

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
            playerHand = Dependencies.Instance.PlayerCardHand;
        }

        private void Start()
        {
            var cardsToPool = new Dictionary<string, GameObject>();
            AddHands(cardsToPool); 
            CreatePools(cardsToPool); 
        }

        private void AddHands(Dictionary<string, GameObject> cardsToPool)
        {
            Debug.Log(playerHand.Cards.Length);
            
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
