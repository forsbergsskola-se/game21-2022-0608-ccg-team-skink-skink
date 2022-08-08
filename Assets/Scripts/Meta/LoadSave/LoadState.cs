using System.IO;
using UnityEngine;

namespace Meta.LoadSave
{
    public class LoadState : MonoBehaviour
    {
        private GameState gameState = new ();
        private void Awake()
        {
            string json = File.ReadAllText(Application.dataPath + "/SavedGames/Test_01.json");
            gameState = JsonUtility.FromJson<GameState>(json);
            
            Debug.Log(gameState);
        }
    }
}
