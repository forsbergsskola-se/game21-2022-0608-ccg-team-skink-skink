using Meta.Interfaces;
using UnityEngine;

namespace Meta.Level
{
    [CreateAssetMenu(fileName = "NewLevel", menuName = "ScriptableObjects/Levels/GameplayLevel")]
    public class GameplayLevelSO: ScriptableObject, IGameplayLevel
    {
        [SerializeField] private string visualName;
        [SerializeField] private string description;
        [SerializeField] private string internalSceneName;
        [SerializeField] private string internalSceneSoundBankName;
        [SerializeField] private string gameSoundBank;
        [SerializeField] [RequireInterface(typeof(ICardHand))] private Object enemyCardHand;

        public string Name => visualName;
        public string InternalSceneName => internalSceneName;
        public string InternalSceneSoundBankName => internalSceneSoundBankName;
        public string Description => description;
        public ICardHand EnemyHandPreset => enemyCardHand as ICardHand;
        public string GameSoundBank => gameSoundBank;
    }
}