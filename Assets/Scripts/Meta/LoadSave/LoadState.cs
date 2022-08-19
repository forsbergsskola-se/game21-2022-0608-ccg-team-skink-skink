using System.IO;
using Meta.Interfaces;
using UnityEngine;
using Utility;

namespace Meta.LoadSave
{
    public class LoadState
    {
        private ICardArray cardArray;
        private ICardHand starterCardHand;
        private string saveFilePath = Application.dataPath + "/SavedGames/SavedData.json";

        public LoadState(ICardArray cardArray, ICardHand starterCardHand)
        {
            this.cardArray = cardArray;
            this.starterCardHand = starterCardHand;
        }
        
        public void Load()
        {
            if (!File.Exists(saveFilePath))
            {
                SetStateFromStarterHand();
                return;
            }
            
            var state = GetGameStateFromJson();
            SetGameState(state);
        }

        private GameState GetGameStateFromJson()
        {
            string json = File.ReadAllText(saveFilePath);
            var fromJson = JsonUtility.FromJson<GameState>(json);

            return fromJson;
        }

        /// <summary>
        /// Added this because we need a easy way for the designers to set the starting card hand when you launch the game.
        /// It would maybe have been preferred to do this some other way. But we can do refinements later.
        /// </summary>
        private void SetStateFromStarterHand()
        {
            var playerCardHand = Dependencies.Instance.PlayerCardHand;
            for (int i = 0; i < playerCardHand.Cards.Length; i++)
            {
                playerCardHand[i] = starterCardHand.Cards[i];
            }

            foreach (var card in starterCardHand.Cards)
            {
                Dependencies.Instance.Inventory.Add(card);
            }
        }

        private void SetGameState(GameState state)
        {
            Dependencies.Instance.NormalCoinCarrier.Amount = state.currency;
            Dependencies.Instance.LootBoxAmountModel.Amount = state.lootBoxesAmount;
            SetCardHand(state.cardHand);
            SetInventory(state.inventoryID,state.inventoryAmount);
            Dependencies.Instance.LevelsModel.CurrentMaxLevelIndex = state.currentLevel;
        }

        private void SetCardHand(int[] indexes)
        {
            var cardHand = Dependencies.Instance.PlayerCardHand;
            
            for (int i = 0; i < cardHand.Cards.Length; i++)
                cardHand[i] = cardArray.GetCard(indexes[i]);
        }

        private void SetInventory(int[] indexes, int[] amounts)
        {
            var inventory = Dependencies.Instance.Inventory;

            for (int i = 0; i < indexes.Length; i++)
            {
                for (int j = 1; j <= amounts[i]; j++)
                {
                    inventory.Add(cardArray.GetCard(indexes[i]));
                }
            }
        }
    }
}
