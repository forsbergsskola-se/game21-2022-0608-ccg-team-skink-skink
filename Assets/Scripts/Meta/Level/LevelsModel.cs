using System;
using Meta.Interfaces;
using UnityEngine;

namespace Meta.Level 
{
    public class LevelsModel : ILevelsModel {
        public event Action<int> MaxLevelIndexChanged;

        int currentMaxLevelIndex;
        
        public int CurrentMaxLevelIndex
        {
            get => currentMaxLevelIndex;
            set
            {
                currentMaxLevelIndex = value;
                MaxLevelIndexChanged?.Invoke(value);
            } 
        }
        
        public IGameplayLevel CurrentLevel { get; private set; }
        
        public int CurrentLevelIndex { get; private set; }
        public void SetCurrentLevel(IGameplayLevel level, int levelIndex)
        {
            CurrentLevel = level;
            CurrentLevelIndex = levelIndex;
            Debug.Log(level);
            Debug.Log(levelIndex);
        }
    }
}
