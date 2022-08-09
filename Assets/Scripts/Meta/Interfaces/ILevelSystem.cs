namespace Meta.Interfaces
{
    public interface ILevel
    {
        public string Name { get; }
        public string InternalSceneName { get; }
        public string InternalSceneSoundBankName { get; }
        public string Description { get; }
    }

    public interface IGameplayLevel : ILevel
    {
        public ICardHand EnemyHandPreset { get; }
        public string GameSoundBank { get; }
    }
}
