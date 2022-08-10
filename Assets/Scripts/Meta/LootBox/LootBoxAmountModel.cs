using System;
using Meta.Interfaces;

namespace Meta.LootBox
{
    public class LootBoxAmountModel : ILootBoxAmountModel
    {
        private int amount;
        public int Amount
        {
            get => amount;
            set
            {
                amount = value;
                ValueChanged?.Invoke(value);
            }
        }
        public event Action<int> ValueChanged;
    }
}
