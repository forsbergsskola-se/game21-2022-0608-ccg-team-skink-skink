using Meta.Interfaces;
using UnityEngine;
using Object = UnityEngine.Object;
namespace Meta.CardSystem
{
    [CreateAssetMenu(fileName = "NewCard", menuName = "ScriptableObjects/CardSystem/Card")]
    public class CardSO : ScriptableObject, ICard
    {
        [SerializeField] private string description;
        [SerializeField] private string cardTitle;
        [SerializeField] private Sprite cardImage;
        [SerializeField] private Sprite typeImage;
        [SerializeField] private int level;
        [SerializeField] private int apCost;
        [SerializeField] private int coolDownTime;
        [SerializeField] private GameObject unitPrefab;
        [SerializeField, RequireInterface(typeof(ICard))] Object upgradedCard;
        static sbyte nextId;
        public CardSO()
        {
            Id = nextId++;
            tempId = Id;
        }
        public int CoolDownTime => coolDownTime;
        public string Description => description;
        public Sprite CardImage => cardImage;
        public Sprite TypeImage => typeImage;
        
        public string Name => cardTitle;
        public ICard UpgradedCard => upgradedCard as ICard;
        public int CardLevel => level;
        public sbyte Id { get; }
        public int ApCost => apCost;
        public GameObject CardObject => unitPrefab;
        
        //TODO:TEMPORARY
        [SerializeField]
        sbyte tempId;
    }
}
