using Meta.Interfaces;
using UnityEngine;

namespace Meta.InventorySystem
{
    [CreateAssetMenu(fileName = "NewCardHand", menuName = "CardSystem/Cardhand")]
    public class CardHandSO : ScriptableObject, ICardHand
    {
        [SerializeField] private CardSO abilityCard;
        [SerializeField] private CardSO[] cards = new CardSO[6];
        
        public ICard[] Cards => cards;

        public ICard AbilityCard
        {
            get => abilityCard;
            set
            {
                abilityCard = (CardSO) value;
            } 
        }
    }
}
