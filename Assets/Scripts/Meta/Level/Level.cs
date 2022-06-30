using System.Runtime.CompilerServices;
using Meta.Interfaces;
using Meta.InventorySystem;
using UnityEngine;

namespace Meta.Level
{
    public class Level : MonoBehaviour, ILevel
    {
        //Neither viualName nor index is being used, what are their purposes?
        [SerializeField] private string visualName;
        [SerializeField] private int index;
        [SerializeField] private string internalSceneName;
        [SerializeField] private string internalSceneSoundBankName;

        [SerializeField, RequireInterface(typeof(ICardHand))] private Object enemyCardHand;

        public string Name => visualName;
        public int Index => index;
        public ICardHand EnemyHandPreset => enemyCardHand as ICardHand;
        public string InternalSceneName => internalSceneName;
        public string InternalSceneSoundBankName => internalSceneSoundBankName;
    }
}
