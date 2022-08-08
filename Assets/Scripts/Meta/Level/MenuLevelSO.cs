using System.Runtime.CompilerServices;
using Meta.Interfaces;
using Meta.InventorySystem;
using UnityEngine;

namespace Meta.Level
{
    [CreateAssetMenu(fileName = "NewLevel", menuName = "ScriptableObjects/Levels/MenuLevel")]
    public class MenuLevelSO : ScriptableObject, ILevel
    {
        //Neither visualName nor index is being used, what are their purposes?
        [SerializeField] private string visualName;
        [SerializeField] private string internalSceneName;
        [SerializeField] private string internalSceneSoundBankName;
        
        public string Name => visualName;
        public string InternalSceneName => internalSceneName;
        public string InternalSceneSoundBankName => internalSceneSoundBankName;
    }
}
