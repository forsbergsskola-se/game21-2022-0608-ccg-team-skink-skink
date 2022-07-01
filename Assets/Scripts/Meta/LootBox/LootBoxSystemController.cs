using Meta.Interfaces;
using UnityEngine;
using Utility;


namespace Meta.LootBox
{
    public class LootBoxSystemController : MonoBehaviour
    {
        private ILootBoxInventoryModel lootBoxInventoryModel;

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
