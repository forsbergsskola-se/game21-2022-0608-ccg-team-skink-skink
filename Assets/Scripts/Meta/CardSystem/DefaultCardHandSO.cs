using System;
using Meta.Interfaces;
using UnityEngine;
using Object = UnityEngine.Object;

namespace Meta.InventorySystem
{
    [CreateAssetMenu(fileName = "NewDefaultCardHand", menuName = "ScriptableObjects/CardSystem/DefaultCardhand")]
    public class DefaultCardHandSO : ScriptableObject, ICardHand
    {
        [SerializeField, RequireInterface(typeof(ICard))] private Object abilityCard;
        [SerializeField, RequireInterface(typeof(ICard))] private Object[] cards = new Object[6];

        public ICard[] Cards
        {
            get => Array.ConvertAll(cards, card => card as ICard);
        }

        public ICard AbilityCard
        {
            get => abilityCard as ICard;
        }
    }
}
