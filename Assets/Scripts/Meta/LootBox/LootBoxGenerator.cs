using Meta.Interfaces;
using Random = System.Random;

namespace Meta.LootBox
{
    public class LootBoxGenerator : ILootBoxGenerator
    {
        public ICard[] GetLoot(CardsTierSO cardTier, int rarityMultiplier)
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
