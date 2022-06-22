using Meta.Interfaces;
using UnityEngine;

namespace Meta.InventorySystem
{
    [CreateAssetMenu(fileName = "NewCard", menuName = "ScriptableObjects/CardSystem/Card")]
    public class CardSO : ScriptableObject, ICard
    {
        [SerializeField] string cardTitle;
        [SerializeField] private Sprite cardImage;
        [SerializeField] int level;
        [SerializeField] int apCost;
        [SerializeField] GameObject unitPrefab;
        [SerializeField] private int coolDownTime;

        public Sprite Image => cardImage;
        public string Name => cardTitle;
        public int CardLevel => level;
        public int ApCost => apCost;
        public GameObject CardObject => unitPrefab;
        public int CoolDownTime => coolDownTime;
    }
}
