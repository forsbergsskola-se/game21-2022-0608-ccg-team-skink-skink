using System.IO;
using UnityEngine;
using Utility;

namespace Meta.LoadSave
{
    public class LoadState
    {
        private GameState state;
        private CardArraySO cardArray;

        public LoadState(GameState state, CardArraySO cardArray)
        {
            this.state = state;
            this.cardArray = cardArray;
        }

        public GameState Load()
        {
            state = GetGameStateFromJson();
            SetGameState(state);

            return state;
        }

        private GameState GetGameStateFromJson()
        {
            string json = File.ReadAllText(Application.dataPath + "/SavedGames/SavedData.json");
            var fromJson = JsonUtility.FromJson<GameState>(json);

            return fromJson;
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
