using Meta.Interfaces;
using UnityEngine;

namespace Meta.Level
{
    [CreateAssetMenu(fileName = "NewLevel", menuName = "ScriptableObjects/Levels/MenuLevel")]
    public class MenuLevelSO : ScriptableObject, ILevel
    {
        //Neither visualName nor index is being used, what are their purposes?
        [SerializeField] private string visualName;
        [SerializeField] private string description;
        [SerializeField] private string internalSceneName;
        [SerializeField] private string internalSceneSoundBankName;
        
        public string Name => visualName;
        public string InternalSceneName => internalSceneName;
        public string InternalSceneSoundBankName => internalSceneSoundBankName;
        public string Description => description;
    }
}
