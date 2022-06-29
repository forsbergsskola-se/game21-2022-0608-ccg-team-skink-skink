using System.Collections.Generic;
using Meta.Interfaces;
using UnityEngine;
using Utility;

namespace Meta.LootBox
{
    public class LootBox : MonoBehaviour, ILootBoxSystem
    {
        [Header("Cards List")] 
        
        [SerializeField] private CardsTierSO cards;
        [SerializeField] private int rarityMultiplier;

        private LootBoxGenerator generator;

        private void Start()
        {
            for (int i = 0; i < 3; i++)
            {
                CreateNewLootBox();
                Debug.Log(LootBoxes);
            }

            OpenLootBox(cards, rarityMultiplier);
        }

        public void OpenLootBox(CardsTierSO cardsTier, int rarityMultiplyer)
        {
            if (LootBoxes <= 0) return;

            LootBoxes--;
            
            generator = new();
            var loot = generator.GetLoot(cardsTier, rarityMultiplyer);
            
            foreach (var card in loot)
            {
                Dependencies.Instance.Inventory.Add(card);
                Debug.Log(card.Name);
            }
            
            Debug.Log(Dependencies.Instance.Inventory.Cards.Count);
        }

        public void CreateNewLootBox() => LootBoxes++;
        
        public int LootBoxes { get; private set; }
    }
}
