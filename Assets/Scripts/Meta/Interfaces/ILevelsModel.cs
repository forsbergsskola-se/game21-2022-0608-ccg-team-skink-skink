using System;
namespace Meta.Interfaces 
{
    public interface ILevelsModel
    {
        public event Action<int> MaxLevelIndexChanged; 
        public int CurrentMaxLevelIndex { get; set; }
        public IGameplayLevel CurrentLevel { get; }
        public int CurrentLevelIndex { get; }
        public void SetCurrentLevel(IGameplayLevel level, int levelIndex);
    }
}
