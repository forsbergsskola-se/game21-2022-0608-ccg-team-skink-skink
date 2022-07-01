using Meta.Interfaces;
using UnityEngine;

namespace Meta.Level
{
    [CreateAssetMenu(fileName = "NewLevel", menuName = "ScriptableObjects/Levels/GameplayLevel")]
    public class GameplayLevelSO: ScriptableObject, IGameplayLevel
    {
        [SerializeField] private string visualName;
        [SerializeField] private int index;
        [SerializeField] private string internalSceneName;
        [SerializeField] private string internalSceneSoundBankName;
        [SerializeField] private string gameSoundBank;
        [SerializeField] [RequireInterface(typeof(ICardHand))] private Object enemyCardHand;

        public string Name => visualName;
        public int Index => index;
        public string InternalSceneName => internalSceneName;
        public string InternalSceneSoundBankName => internalSceneSoundBankName;
        public ICardHand EnemyHandPreset => enemyCardHand as ICardHand;
        public string GameSoundBank => gameSoundBank;
    }
}