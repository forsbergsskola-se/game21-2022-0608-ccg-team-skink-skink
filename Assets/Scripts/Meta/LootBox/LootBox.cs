using System;
using Meta.Interfaces;
using Utility;

namespace Meta.LootBox
{
    public class LootBox : ILootBoxSystem
    {
        public int Amount { get; private set; }
        public void CreateNewLootBox() => Amount++;

        public ICard[] OpenLootBox(CardsTierSO cardsTier, int rarityMultiplier)
        {
            if (Amount <= 0)
            {
                throw new ArgumentException(
                    "There is no LootBox to open. Please call 'CreateNewLootBox()' before open it.");
            }
            
            Amount--;
            
            var loot = GetLoot(cardsTier, rarityMultiplier);
            
            foreach (var card in loot)
                Dependencies.Instance.Inventory.Add(card);

            return loot;
        }

        private ICard[] GetLoot(CardsTierSO cardTier, int rarityMultiplier)
        {
            var random = new Random();
            
            ICard[] loot = new ICard[3];

            loot[0] = GetRandom(cardTier.Common, random);
            loot[1] = GetRandom(cardTier.Uncommon, random);

            var rareChance = random.Next(0, rarityMultiplier);

            if (rareChance == 0) loot[2] = GetRandom(cardTier.Rare, random);
            else loot[2] = GetRandom(cardTier.Common, random);
            
            return loot;
        }
        
        private ICard GetRandom(ICard[] cards, Random random) => cards[random.Next(0, cards.Length - 1)];
    }
}
