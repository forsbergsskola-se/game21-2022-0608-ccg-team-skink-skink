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
        [SerializeField, RequireInterface(typeof(ICard))] private Object[] cards;

        public ICard[] Cards => Array.ConvertAll(cards, card => card as ICard);
        public ICard AbilityCard => abilityCard as ICard;
    }
}
