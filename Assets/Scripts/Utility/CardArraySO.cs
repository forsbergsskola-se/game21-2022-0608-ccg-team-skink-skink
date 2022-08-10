using Meta.Interfaces;
using UnityEngine;

namespace Utility
{
    [CreateAssetMenu(menuName = "ScriptableObjects/Utilities/CardArray",fileName = "NewCardArray")]
    public class CardArraySO : ScriptableObject
    {
        [SerializeField, RequireInterface(typeof(ICard))]
        private Object[] cards;

        public ICard GetCard(int id) => cards[id] as ICard;

        public Object[] GetCollection() => cards;
    }
}
