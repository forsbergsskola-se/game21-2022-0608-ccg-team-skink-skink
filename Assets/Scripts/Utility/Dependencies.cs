using Meta.CardSystem;
using Meta.CurrencySystem;
using Meta.Interfaces;
using Meta.Level;
using Meta.LootBox;
using UnityEngine;

namespace Utility
{
    public class Dependencies : MonoBehaviour
    {
        public readonly IInventory Inventory = new InventoryModel();
        public readonly ISettableCardHand PlayerCardHand = new PlayerCardHand();
        public readonly INormalCoinCarrier NormalCoinCarrier = new NormalCoinWallet();
        public readonly IPremiumCoinCarrier PremiumCoinCarrier;
        public readonly ILootBoxAmountModel LootBoxAmountModel = new LootBoxAmountModel();
        public readonly ILevelLoader LevelLoader = new LevelLoader();
        
        
        public static Dependencies Instance { get; private set; }

        void Awake()
        {
            if (Instance != null && Instance != this)
            {
                Destroy(gameObject);
                return;
            }

            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }
}
