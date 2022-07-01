namespace Meta.Interfaces
{
    public interface ILootBoxAmountModel
    {
        /// <summary>
        /// Holds the current number of owned lootboxes.
        /// </summary>
        public int Amount { get; set; }
    }
}