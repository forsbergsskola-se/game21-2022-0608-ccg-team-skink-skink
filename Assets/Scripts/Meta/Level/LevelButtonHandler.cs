using Meta.Interfaces;
using UnityEngine;

namespace Meta.Level
{
    public class LevelButtonHandler : MonoBehaviour
    {
        public void StartLoadingLevel()
        {
            var level = GetComponent<ILevel>();
            var levelLoader = FindObjectOfType<LevelLoader>();
            
            // TODO: Do stuff before loading?

            levelLoader.LoadLevel(level);
        }

        public void StartLoadingMetaScene()
        {
            var level = GetComponent<ILevel>();
            var levelLoader = FindObjectOfType<MetaSceneLoader>();
            
            // TODO: Do stuff before loading?

            levelLoader.LoadLevel(level);
        }
    }
}
