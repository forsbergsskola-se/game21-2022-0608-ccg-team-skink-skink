using System;
using System.Collections.Generic;
using Meta.Interfaces;
using UnityEngine;
using Utility;
using Object = UnityEngine.Object;

namespace Meta.LootBox
{
    public class LootBox : MonoBehaviour, ILootBoxSystem
    {
        [Header("Cards List")]
        [SerializeField, RequireInterface(typeof(ICard))] private Object[] rare;
        [SerializeField, RequireInterface(typeof(ICard))] private Object[] uncommon;
        [SerializeField, RequireInterface(typeof(ICard))] private Object[] common;
        
        [SerializeField] private int rarityMultiplier;

        private LootBoxGenerator generator;

        private void Start()
        {
            for (int i = 0; i < 3; i++)
            {
                CreateNewLootBox();
                Debug.Log(LootBoxes);
            }
            
            OpenLootBox(Array.ConvertAll(rare, card => card as ICard),
                Array.ConvertAll(uncommon, card => card as ICard),
                Array.ConvertAll(common, card => card as ICard),
                rarityMultiplier);
            
            Debug.Log(LootBoxes);
        }

        public void OpenLootBox(ICard[] rareCards, ICard[] uncommonCards, ICard[] commonCards, int rarityMultiplyer)
        {
            if (LootBoxes <= 0) return;

            LootBoxes--;
            
            List<ICard[]> cards = new List<ICard[]>();
            cards.Add(Array.ConvertAll(rare, card => card as ICard));
            cards.Add(Array.ConvertAll(uncommon, card => card as ICard));
            cards.Add(Array.ConvertAll(common, card => card as ICard));
            
            generator = new LootBoxGenerator(cards, rarityMultiplier);
            
            var loot = generator.GetLoot();
            
            foreach (var card in loot)
            {
                Dependencies.Instance.Inventory.Add(card);
                Debug.Log(card.Name);
            }
        }

        public void CreateNewLootBox() => LootBoxes++;
        
        public int LootBoxes { get; private set; }
    }
}
