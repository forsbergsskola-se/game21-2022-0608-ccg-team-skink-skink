using System;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using Utility;

namespace Meta.LoadSave
{
    public class SaveState 
    {
        private ICardArray cardArray;

        public SaveState(ICardArray cardArray) => this.cardArray = cardArray;
        
        public void Save(GameState state)
        {
            state = GetGameStateFromDependencies();
            SetGameStateToJson(state);
        }

        public void SetGameStateToJson(GameState state)
        {
            var toJson = JsonUtility.ToJson(state);
            File.WriteAllText(Application.dataPath + "/SavedGames/SavedData.json", toJson);
        }

        private GameState GetGameStateFromDependencies()
        {
            var currentState = new GameState();

            currentState.currency = Dependencies.Instance.NormalCoinCarrier.Amount;
            currentState.lootBoxesAmount = Dependencies.Instance.LootBoxAmountModel.Amount;
            currentState.cardHand = GetCardHandFromDependencies();

            currentState.inventoryID = GetInventoryFromDependencies(out List<int> amount).ToArray();
            currentState.inventoryAmount = amount.ToArray();
            currentState.currentLevel = Dependencies.Instance.LevelsModel.CurrentMaxLevelIndex;
            
            return currentState;
        }

        private int[] GetCardHandFromDependencies()
        {
            int[] currentCardHand = new int[6];
            var cardCollection = cardArray.GetCollection();
            var cardsFromOnDependencies = Dependencies.Instance.PlayerCardHand.Cards;
            
            for (int i = 0; i < cardsFromOnDependencies.Length; i++)
                currentCardHand[i] = Array.IndexOf(cardCollection, cardsFromOnDependencies[i]);
            
            return currentCardHand;
        }

        private List<int> GetInventoryFromDependencies(out List<int> amount)
        {
            var id = new List<int>();
            amount = new List<int>();
            
            var inventory = Dependencies.Instance.Inventory.Cards;
            var cardCollection = cardArray.GetCollection();

            foreach (var cardList in inventory)
            {
                int index = Array.IndexOf(cardCollection, cardList.Value[0]);
                
                id.Add(index);
                amount.Add(cardList.Value.Count);
            }

            return id;
        }
    }
}
