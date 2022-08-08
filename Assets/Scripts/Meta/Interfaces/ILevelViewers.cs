namespace Meta.Interfaces
{
    public interface IBasicLevelViewer
    {
        public bool Unlocked { get; set; }
    }

    public interface IDetailedLevelViewer
    {
        public void ActivateDetailedLevelViewer(IGameplayLevel gameplayLevel);
    }
}