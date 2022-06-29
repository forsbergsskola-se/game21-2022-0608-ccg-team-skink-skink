using System;
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
        [SerializeField] private CurrencyValueSettings currencyValueSettings;
        static sbyte nextId;
        public CardSO()
        {
            Id = nextId++;
        }
        public int CoolDownTime => coolDownTime;
        public string Description => description;
        public Sprite CardImage => cardImage;
        public Sprite TypeImage => typeImage;
        
        public string Name => cardTitle;
        public ICard UpgradedCard => upgradedCard as ICard;
        public int SellCost => currencyValueSettings.SellCost;
        public int UpgradeCost => currencyValueSettings.UpgradeCost;
        public int CardLevel => level;
        public sbyte Id { get; }
        public int ApCost => apCost;
        public GameObject CardObject => unitPrefab;

        public override bool Equals(object other)
        {
            var otherCard = other as ICard;
            if (otherCard == null)
                return false;
            return otherCard.Id == Id; 
        }
    }
    
    [Serializable]
    public class CurrencyValueSettings
    {
        [SerializeField] public int SellCost = 50;
        [SerializeField] public int UpgradeCost = 100;
    }
}
