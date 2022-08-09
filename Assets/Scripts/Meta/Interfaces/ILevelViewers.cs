using System;

namespace Meta.Interfaces
{
    public interface IBasicLevelViewer
    {
        public IGameplayLevel Level { get; set; }
        public event Action<int> OnClick;
        public bool Unlocked { get; set; }
    }

    public interface IDetailedLevelViewer
    {
        public void ActivateDetailedLevelViewer(IGameplayLevel gameplayLevel);
    }
}