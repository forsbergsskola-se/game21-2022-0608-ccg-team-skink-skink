using Meta.Interfaces;
using UnityEngine;
using Utility;


namespace Meta.LootBox
{
    public class LootBoxSystemController : MonoBehaviour
    {
        private ILootBoxSystem lootBoxSystem;

        [SerializeField, RequireInterface(typeof(ILootBoxViewer))] private Object lootBoxViewer;

        private void Awake()
        {
            
        }

        public void OpenLootBox()
        {
            
        }

        public void EnableLootBoxScreen()
        {
        
        }

        public void DisableLootBoxScreen()
        {
        
        }
    }
}
