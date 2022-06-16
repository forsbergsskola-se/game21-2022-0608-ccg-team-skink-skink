using Meta.Interfaces;
using UnityEngine;

namespace Meta.InventorySystem
{
    [CreateAssetMenu(fileName = "NewCardHand", menuName = "CardSystem/Cardhand")]
    public class CardHandSO : ScriptableObject, ICardHand
    {
        [SerializeField, RequireInterface(typeof(ICard))] private Object abilityCard;
        [SerializeField, RequireInterface(typeof(ICard))] private Object[] cards = new Object[6];

        //public ICard[] Cards => cards as ICard[];
        public ICard[] Cards => GetCards();
        public ICard AbilityCard => abilityCard as ICard;

        //Todo: Get rid of this method :)
        public ICard[] GetCards()
        {
            ICard[] temp = new ICard[6];

            for (int i = 0; i < temp.Length; i++)
            {
                temp[i] = cards[i] as ICard;
            }

            return temp;
        }
    }
}
