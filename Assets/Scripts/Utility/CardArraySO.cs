using Meta.Interfaces;
using Meta.LoadSave;
using UnityEngine;

namespace Utility
{
    [CreateAssetMenu(menuName = "ScriptableObjects/Utilities/CardArray",fileName = "NewCardArray")]
    public class CardArraySO : ScriptableObject, ICardArray
    {
        [SerializeField, RequireInterface(typeof(ICard))]
        private Object[] cards;

        public ICard GetCard(int id) => cards[id] as ICard;

        public object[] GetCollection() => cards;
    }
}
