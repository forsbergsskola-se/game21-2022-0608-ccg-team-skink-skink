using System;
using System.Linq;
using Meta.Interfaces;
using UnityEngine;

namespace Meta.InventorySystem
{
    [CreateAssetMenu(fileName = "NewCardHand", menuName = "CardSystem/Cardhand")]
    public class CardHandSO : ScriptableObject, ICardHand
    {
        [SerializeField] private CardSO abilityCard;
        [SerializeField] private CardSO[] cards = new CardSO[6];

        private void Awake()
        {
            Debug.Log("I'm awake, need coffee tho");
            //Cards = cards.ToArray<ICard>();
            AbilityCard = abilityCard;
        }

        public ICard[] Cards => cards;
        
        public ICard AbilityCard { get; set; }
        
    }
}
