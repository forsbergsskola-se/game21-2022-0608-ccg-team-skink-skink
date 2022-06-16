using Meta.Interfaces;
using UnityEngine;

namespace Meta.InventorySystem
{
    [CreateAssetMenu(fileName = "NewCardHand", menuName = "CardSystem/Cardhand")]
    public class CardHandSO : ScriptableObject, ICardHand
    {
        [SerializeField, RequireInterface(typeof(ICardHand))] private Object abilityCard;
        [SerializeField, RequireInterface(typeof(ICardHand))] private Object[] cards = new Object[6];

        public ICard[] Cards => cards as ICard[];
        public ICard AbilityCard => abilityCard as ICard;
    }
}
