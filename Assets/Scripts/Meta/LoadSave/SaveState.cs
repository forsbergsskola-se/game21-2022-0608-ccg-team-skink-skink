using System;
using System.IO;
using Unity.VisualScripting;
using UnityEngine;
using Utility;

namespace Meta.LoadSave
{
    public class SaveState : MonoBehaviour
    {
        [SerializeField] private CardArraySO cardArray;

        private GameState gameState = new GameState();

        public void SetGameStateToJson(GameState state)
        {
            var toJson = JsonUtility.ToJson(state);
            File.WriteAllText(Application.dataPath + "/SavedGames/Test_save.json", toJson);
        }

        public void Start()
        {
            gameState.currency = Dependencies.Instance.NormalCoinCarrier.Amount;
            gameState.lootBoxesAmount = Dependencies.Instance.LootBoxAmountModel.Amount;
            //TODO Add CurrentLevel
            gameState.cardHand = GetCardHandFromDependencies();
            //TODO Add GetInventory
            
            SetGameStateToJson(gameState);
        }

        private int[] GetCardHandFromDependencies()
        {
            int[] currentCardHand = new int[6];
            var cardCollection = this.cardArray.GetHand();
            var cardsOnDependencies = Dependencies.Instance.PlayerCardHand.Cards;
            for (int i = 0; i < cardsOnDependencies.Length; i++)
            {
                currentCardHand[i] = Array.IndexOf(cardCollection, cardsOnDependencies[i]);
            }
            return currentCardHand;
        }
    }
}
