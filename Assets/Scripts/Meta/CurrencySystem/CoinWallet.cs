using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Meta.Interfaces;

namespace Meta.CurrencySystem
{
    public class NormalCoinWallet : INormalCoinCarrier
    {
        public event Action<int> ValueChanged;
        private int amount;
        
        public int Amount
        {
            get=> amount;
            set
            {
                amount = value;
                ValueChanged?.Invoke(value);
            }
        }
    }
    
    public class PremiumCoinWallet : IPremiumCoinCarrier
    {
        public event Action<int> ValueChanged;
        private int amount;
        
        public int Amount
        {
            get=>amount;
            set
            {
                amount = value;
                ValueChanged?.Invoke(value);
            }
        }
        
    }
    
}
