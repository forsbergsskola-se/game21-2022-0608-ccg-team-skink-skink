using UnityEngine;
using Utility;
namespace Meta.Level {
    public class LoadGameplayLevel : MonoBehaviour 
    {
        public void LoadCurrentLevel() 
        {
            Dependencies.Instance.LevelLoader.LoadLevel(Dependencies.Instance.LevelsModel.CurrentLevel);
        }
    }
}
