using System.Collections.Generic;

namespace Meta.Interfaces
{
    public interface ILootBoxSystem
    {
        /// <summary>
        ///  Creates a new lootbox based on the provided rarity float, and adds it to the lootbox inventory.
        /// </summary>
        /// <param name="rarityMultiplier"></param>
        public void CreateNewLootBox(float rarityMultiplier);

        /// <summary>
        /// Holds the current owned and unopened lootboxes. We have a list of lists to be able to group lootboxes depending on class/rarity/level depending on designer choice.
        /// </summary>
        public List<List<ILootBox>> LootBoxes { get; }
    }

    public interface ILootBox
    {
        /// <summary>
        /// Opens this lootbox and adds contents to the users card inventory.
        /// </summary>
        public void OpenLootBox();
    }

    public interface ILootBoxGenerator
    {
        /// <summary>
        /// Return the Loot
        /// </summary>
        public ICard[] Loot();
    }

}