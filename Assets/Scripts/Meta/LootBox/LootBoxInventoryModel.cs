using System;
using Meta.Interfaces;
using UnityEngine;
using Utility;
using Random = System.Random;

namespace Meta.LootBox
{
    public class LootBoxInventoryModel : MonoBehaviour, ILootBoxInventoryModel
    {
        [SerializeField] private CardsTierSO lootBoxData;
        [SerializeField] private int rarityMultiplier;

        private ILootBoxAmountModel lootBoxAmountModel;

        private void Awake()
        {
            lootBoxAmountModel = Dependencies.Instance.LootBoxAmountModel;
        }

        public ICard[] OpenLootBox()
        {
            if (lootBoxAmountModel.Amount <= 0)
                throw new Exception(
                    "Can't open lootbox when the amount left is 0! Why are you not checking before calling this?");

            lootBoxAmountModel.Amount--;
            
            var loot = GetLoot();

            LootBoxOpened?.Invoke(loot);
            return loot;
        }

        public event Action<ICard[]> LootBoxOpened;

        public int Amount => lootBoxAmountModel.Amount;


        private ICard[] GetLoot()
        {
            var random = new Random();
            
            var loot = new ICard[3];

            loot[0] = GetRandom(lootBoxData.Common, random);
            loot[1] = GetRandom(lootBoxData.Uncommon, random);

            var rareChance = random.Next(0, rarityMultiplier);

            if (rareChance == 0) loot[2] = GetRandom(lootBoxData.Rare, random);
            else loot[2] = GetRandom(lootBoxData.Common, random);
            
            return loot;
        }
        
        private ICard GetRandom(ICard[] cards, Random random) => cards[random.Next(0, cards.Length - 1)];
    }
}
