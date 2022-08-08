namespace Meta.LoadSave
{
    public class GameState
    {
        public int currency;
        public int lootBoxesAmount;
        public int currentLevel;
        
        
        public override string ToString() => $"Currency: {currency}\n" +
                                             $"LootBoxesAmount: {lootBoxesAmount}\n" +
                                             $"Current Level: {currentLevel}\n";
    }
}
