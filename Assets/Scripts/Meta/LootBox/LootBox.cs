using System;
using System.Collections.Generic;
using Meta.Interfaces;
using UnityEngine;
using Object = UnityEngine.Object;

namespace Meta.LootBox
{
    public class LootBox : MonoBehaviour, ILootBox
    {
        [Header("Cards List")]
        [SerializeField, RequireInterface(typeof(ICard))] private Object[] rare;
        [SerializeField, RequireInterface(typeof(ICard))] private Object[] uncommon;
        [SerializeField, RequireInterface(typeof(ICard))] private Object[] common;
        
        [SerializeField] private int rarityMultiplier;

        private LootBoxGenerator generator;

        private void Start()
        {
            List<ICard[]> cards = new List<ICard[]>();
            
            cards.Add(Array.ConvertAll(rare, card => card as ICard));
            cards.Add(Array.ConvertAll(uncommon, card => card as ICard));
            cards.Add(Array.ConvertAll(common, card => card as ICard));
            
            generator = new LootBoxGenerator(cards, rarityMultiplier);
            
            OpenLootBox();
        }

        public void OpenLootBox()
        {
            var loot = generator.Loot();
            //Todo: Add loot into the dependencies

            foreach (var card in loot)
            {
                Debug.Log(card.Name);
            }
        }
    }
}
