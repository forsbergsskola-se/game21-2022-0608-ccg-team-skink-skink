using System;
using System.IO;
using Unity.VisualScripting;
using UnityEngine;
using Utility;

namespace Meta.LoadSave
{
    public class SaveState : MonoBehaviour
    {
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
            //TODO Add CardHand
            //TODO Add GetInventory
            
            SetGameStateToJson(gameState);
        }
    }
}
