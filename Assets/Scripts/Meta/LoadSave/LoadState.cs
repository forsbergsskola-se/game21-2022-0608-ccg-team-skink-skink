using System.IO;
using UnityEngine;
using Utility;

namespace Meta.LoadSave
{
    public class LoadState : MonoBehaviour
    {
        private GameState gameState;
        
        private void Awake()
        {
            gameState = GetGameState();
            SetGameState(gameState);
        }

        private GameState GetGameState()
        {
            string json = File.ReadAllText(Application.dataPath + "/SavedGames/Test_01.json");
            var fromJson = JsonUtility.FromJson<GameState>(json);

            Debug.Log(fromJson);

            for (int i = 0; i < fromJson.inventoryID.Length; i++)
            {
                Debug.Log($"ID: {fromJson.inventoryID[i]} | Amount: {fromJson.inventoryAmount[i]}");
            }

            return fromJson;
        }

        private void SetGameState(GameState gameState)
        {
            //Todo: Add Currency
            //Todo: Add LootBoxesAmount
            //Todo: Add Current Level
            //Todo: Add CardHand
            //Todo: Add Inventory ID and Amount
        }
    }
}
