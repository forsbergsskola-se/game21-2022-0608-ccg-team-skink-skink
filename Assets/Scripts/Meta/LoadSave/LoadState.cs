using System.IO;
using UnityEngine;

namespace Meta.LoadSave
{
    public class LoadState : MonoBehaviour
    {
        private void Awake()
        {
            string json = File.ReadAllText(Application.dataPath + "/SavedGames/Test_01.json");
            
            Debug.Log(json);
        }
    }
}
