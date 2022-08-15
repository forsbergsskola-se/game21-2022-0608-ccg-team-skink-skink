namespace Meta.LoadSave
{
    public class GameState
    {
        public int currency;
        public int lootBoxesAmount;
        public int currentLevel;
        public int[] cardHand = new int[6];
        public int[] inventoryID = new int[32];
        public int[] inventoryAmount = new int[32];

        public override string ToString() => $"Currency: {currency}\n" +
                                             $"LootBoxesAmount: {lootBoxesAmount}\n" +
                                             $"Current Level: {currentLevel}\n" +
                                             $"CardHand: {cardHand.Length}\n" +
                                             $"Inventory: {inventoryID.Length}\n" +
                                             $"Inventory: {inventoryAmount.Length}\n";
    }
}
