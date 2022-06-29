using System.Collections.Generic;
using Meta.LootBox;

namespace Meta.Interfaces
{
    public interface ILootBoxSystem
    {
        /// <summary>
        /// Creates a new lootbox based on the provided rarity float, and adds it to the lootbox inventory.
        /// </summary>
        /// <param name="rareCards">Array of Rare ICards - Each Loot box has a chance to have one of them</param>
        /// <param name="uncommonCards">Array of Uncommon ICards - Each Loot box has one of them</param>
        /// <param name="commonCards">Array of Common ICards - Each Loot box has at least one of them</param>
        /// <param name="rarityMultiplier">The odds of getting a Rare ICard is 1 / rarityMultiplier. Bigger the number, smaller the odds.</param>
        public void OpenLootBox(CardsTierSO cardsTier, int rarityMultiplier);
     
        /// <summary>
        ///  Creates a new lootbox based on the provided rarity float, and adds it to the lootbox inventory.
        /// </summary>
        /// <param name="rarityMultiplier"></param>
        public void CreateNewLootBox();

        /// <summary>
        /// Holds the current number of owned lootboxes.
        /// </summary>
        public int LootBoxes { get; }
    }

    public interface ILootBoxGenerator
    {
        /// <summary>
        /// Return the Loot
        /// </summary>
        public ICard[] GetLoot(CardsTierSO cardTier, int rarityMultiplier);
    }

}