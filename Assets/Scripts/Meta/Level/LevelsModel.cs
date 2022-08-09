using System;
using Meta.Interfaces;

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
        public IGameplayLevel CurrentLevel
        {
            get;
            set;
        }
    }
}
