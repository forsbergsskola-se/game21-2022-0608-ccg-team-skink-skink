namespace Meta.LoadSave
{
    public class GameState
    {
        public int currency;
        public int lootBoxesAmount;
        
        
        public override string ToString() => $"Currency: {currency}\n" +
                                             $"LootBoxesAmount: {lootBoxesAmount}\n";
    }
}
