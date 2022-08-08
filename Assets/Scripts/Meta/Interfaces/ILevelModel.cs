namespace Meta.Interfaces 
{
    public interface ILevelsModel
    {
        public int CurrentMaxLevelIndex { get; set; }
        public IGameplayLevel CurrentLevel { get; set; }
    }
}
