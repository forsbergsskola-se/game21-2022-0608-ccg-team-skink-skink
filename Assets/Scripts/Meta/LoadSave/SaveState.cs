using System;
using System.IO;
using UnityEngine;
using Utility;

namespace Meta.LoadSave
{
    public class SaveState : MonoBehaviour
    {
        [SerializeField] private CardArraySO cardArray;

        private GameState gameState = new ();

        public void SetGameStateToJson(GameState state)
        {
            var toJson = JsonUtility.ToJson(state);
            File.WriteAllText(Application.dataPath + "/SavedGames/Test_save.json", toJson);
        }

        public void Awake()
        {
            gameState = GetGameStateFromDependencies();
            SetGameStateToJson(gameState);
        }

        private GameState GetGameStateFromDependencies()
        {
            var currentState = new GameState();
            
            currentState.currency = Dependencies.Instance.NormalCoinCarrier.Amount;
            currentState.lootBoxesAmount = Dependencies.Instance.LootBoxAmountModel.Amount;
            //TODO Add CurrentLevel
            currentState.cardHand = GetCardHandFromDependencies();
            //TODO Add GetInventory

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
    }
}
