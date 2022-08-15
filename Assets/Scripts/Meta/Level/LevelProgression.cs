using Utility;

namespace Meta.Level
{
    public class LevelProgression
    {
        public LevelProgression()
        {
            Dependencies.Instance.EndOfGameRelay.OnWin += OnWin;
        }
        
        private void OnWin()
        {
            if (CompletedLevelIsSameAsMaxLevel())
            {
                Dependencies.Instance.LevelsModel.CurrentMaxLevelIndex++;
            }
        }

        private bool CompletedLevelIsSameAsMaxLevel()
        {
            var levelsModel = Dependencies.Instance.LevelsModel;
            return levelsModel.CurrentLevelIndex == levelsModel.CurrentMaxLevelIndex;
        }
    }
}
