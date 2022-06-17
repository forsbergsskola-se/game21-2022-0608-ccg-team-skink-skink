using System;
using Meta.Interfaces;
using UnityEngine;
using Object = UnityEngine.Object;

namespace Meta.InventorySystem
{
    [CreateAssetMenu(fileName = "NewCardHand", menuName = "ScriptableObjects/CardSystem/Cardhand")]
    public class CardHandSO : ScriptableObject, ICardHand
    {
        [SerializeField, RequireInterface(typeof(ICard))] private Object abilityCard;
        [SerializeField, RequireInterface(typeof(ICard))] private Object[] cards = new Object[6];

        public ICard[] Cards
        {
            get => Array.ConvertAll(cards, card => card as ICard);
            set
            {
                cards = Array.ConvertAll(value, card => card as Object);
            }
        }

        public ICard AbilityCard
        {
            get => abilityCard as ICard;
            set => abilityCard = value as Object;
        }
    }
}
