using System.Collections.Generic;

namespace Meta.Interfaces
{
    public interface ILootBoxSystem
    {
        public void CreateNewLootBox(float rarityMultiplier);

        public List<List<ILootBox>> LootBoxes { get; }
    }

    public interface ILootBox
    {
        public void OpenLootBox();
    }
}