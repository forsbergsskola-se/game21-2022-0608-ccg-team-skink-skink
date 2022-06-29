using System.Collections.Generic;
using Meta.Interfaces;
using Random = System.Random;

namespace Meta.LootBox
{
    public class LootBoxGenerator : ILootBoxGenerator
    {
        private ICard[] Rare { get; }  
        private ICard[] Uncommon { get; }  
        private ICard[] Common { get; }

        private readonly int rarityMultiplier;
        private readonly Random random;
        
        public LootBoxGenerator(List<ICard[]> cards, int rarityMultiplier)
        {
            Rare = cards[0];
            Uncommon = cards[1];
            Common = cards[2];
            
            random = new Random();
            this.rarityMultiplier = rarityMultiplier;
        }
        
        public ICard[] GetLoot()
        {
            ICard[] loot = new ICard[3];

            loot[0] = GetRandom(Common);
            loot[1] = GetRandom(Uncommon);

            var rareChance = random.Next(0, rarityMultiplier);

            if (rareChance == 0) loot[2] = GetRandom(Rare);
            else loot[2] = GetRandom(Common);
            
            return loot;
        }
        
        private ICard GetRandom(ICard[] cards) => cards[random.Next(0, cards.Length - 1)];
    }
}
