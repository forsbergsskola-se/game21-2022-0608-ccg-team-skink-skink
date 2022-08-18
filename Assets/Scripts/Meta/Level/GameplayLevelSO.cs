using Meta.Interfaces;
using UnityEngine;

namespace Meta.Level
{
    [CreateAssetMenu(fileName = "NewLevel", menuName = "ScriptableObjects/Levels/GameplayLevel")]
    public class GameplayLevelSO: ScriptableObject, ILevel
    {
        [SerializeField] private string visualName;
        [SerializeField] private string description;
        [SerializeField] private string internalSceneName;

        public string Name => visualName;
        public string InternalSceneName => internalSceneName;
        public string Description => description;
    }
}