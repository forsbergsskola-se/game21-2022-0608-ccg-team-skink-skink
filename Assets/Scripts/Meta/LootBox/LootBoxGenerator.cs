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
        
        public ICard[] Loot()
        {
            ICard[] loot = new ICard[3];

            loot[0] = Common[random.Next(0, Common.Length - 1)];
            loot[1] = Uncommon[random.Next(0, Uncommon.Length - 1)];

            var rareChance = random.Next(0, rarityMultiplier);

            if (rareChance == 0) loot[2] = Rare[random.Next(0, Rare.Length - 1)];
            else loot[2] = Common[random.Next(0, Common.Length - 1)];
            
            return loot;
        }
    }
}
