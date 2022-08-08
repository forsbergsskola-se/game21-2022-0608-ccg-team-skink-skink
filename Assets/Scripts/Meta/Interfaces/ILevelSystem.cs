namespace Meta.Interfaces
{
    public interface ILevelsModel
    {
        public int CurrentMaxLevelIndex { get; set; }
        public IGameplayLevel CurrentLevel { get; set; }
    }
    
    public interface ILevel
    {
        public string Name { get; }
        public string InternalSceneName { get; }
        public string InternalSceneSoundBankName { get; }
    }

    public interface IGameplayLevel : ILevel
    {
        public ICardHand EnemyHandPreset { get; }
        public string GameSoundBank { get; }
    }
}
