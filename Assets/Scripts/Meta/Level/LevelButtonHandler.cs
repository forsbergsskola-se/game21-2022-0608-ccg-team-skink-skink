using System;
using Meta.Interfaces;
using UnityEngine;
using Utility;
using Object = UnityEngine.Object;

namespace Meta.Level
{
    public class LevelButtonHandler : MonoBehaviour
    {
        [SerializeField, RequireInterface(typeof(ILevel))] private Object level;
        private ILevelLoader levelLoader;
        private void Awake()
        {
            levelLoader = Dependencies.Instance.LevelLoader;
        }

        public void LoadLevel()
        {
            levelLoader.LoadLevel(level as ILevel);
        }
    }
}
