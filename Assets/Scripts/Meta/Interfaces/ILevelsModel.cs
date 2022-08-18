using System;
namespace Meta.Interfaces 
{
    public interface ILevelsModel
    {
        public event Action<int> MaxLevelIndexChanged; 
        public int CurrentMaxLevelIndex { get; set; }
        public ILevel CurrentLevel { get; }
        public int CurrentLevelIndex { get; }
        public void SetCurrentLevel(ILevel level, int levelIndex);
    }
}
