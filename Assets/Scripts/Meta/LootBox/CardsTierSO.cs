using System;
using Meta.Interfaces;
using UnityEngine;
using Object = UnityEngine.Object;

namespace Meta.LootBox
{
    [CreateAssetMenu(fileName = "NewCardsTier", menuName = "ScriptableObjects/LootBoxSystem/CardsTier")]
    public class CardsTierSO : ScriptableObject
    {
        [Header("Cards Tier")]
        [SerializeField, RequireInterface(typeof(ICard))] private Object[] rare;
        [SerializeField, RequireInterface(typeof(ICard))] private Object[] uncommon;
        [SerializeField, RequireInterface(typeof(ICard))] private Object[] common;

        public ICard[] Rare => Array.ConvertAll(rare, card => card as ICard);
        public ICard[] Uncommon => Array.ConvertAll(uncommon, card => card as ICard);
        public ICard[] Common => Array.ConvertAll(common, card => card as ICard);
        
    }
}
