using Meta.Interfaces;
using UnityEngine;

namespace Meta.InventorySystem
{
    [CreateAssetMenu(fileName = "NewCardHand", menuName = "CardSystem/Cardhand")]
    public class CardHandSO : ScriptableObject, ICardHand
    {
        [SerializeField] private CardSO abilityCard;
        [SerializeField] private CardSO[] cards = new CardSO[6];
        
        public void Awake()
        {
            AbilityCard = abilityCard;
            //Cards = cards;
        }

        public ICard[] Cards => cards;
        public ICard AbilityCard { get; set; }
    }
}
