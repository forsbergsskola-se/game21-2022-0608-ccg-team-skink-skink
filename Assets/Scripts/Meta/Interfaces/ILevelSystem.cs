using UnityEngine.SceneManagement;

namespace Meta.Interfaces
{
    public interface ILevelController
    {
        /// <summary>
        /// Load and start the provided level.
        /// </summary>
        /// <param name="level"></param>
        public void LoadLevel(ILevel level);
    }
    public interface ILevel
    {
        //TODO: Either use or scrap the 3 unused properties below
        public string Name { get; }
        public int Index { get; }
        public ICardHand EnemyHandPreset { get; }
        public string InternalSceneName { get; }
        public string InternalSceneSoundBankName { get; }
    }
}
