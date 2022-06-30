using System.Collections.Generic;
using Meta.LootBox;

namespace Meta.Interfaces
{
    public interface ILootBoxSystem
    {
        /// <summary>
        /// Creates a new lootbox based on the provided rarity float, and adds it to the lootbox inventory.
        /// </summary>
        ///  <param name="cardsTier">Scriptable Object</param>
        /// <param name="rarityMultiplier">The odds of getting a Rare ICard is 1 / rarityMultiplier. Bigger the number, smaller the odds.</param>
        public ICard[] OpenLootBox(CardsTierSO cardsTier, int rarityMultiplier);
     
        /// <summary>
        ///  Creates a new lootbox based on the provided rarity float, and adds it to the lootbox inventory.
        /// </summary>
        /// <param name="rarityMultiplier"></param>
        public void CreateNewLootBox();

        /// <summary>
        /// Holds the current number of owned lootboxes.
        /// </summary>
        public int Amount { get; }
    }
}