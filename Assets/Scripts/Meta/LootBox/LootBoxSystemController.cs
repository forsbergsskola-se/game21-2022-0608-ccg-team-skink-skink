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
            lootBoxSystem = Dependencies.Instance.LootBoxSystem;
        }

        public void OpenLootBox()
        {
            // (lootBoxViewer as ILootBoxViewer).SetFromLootBox(lootBoxSystem.OpenLootBox());
        }

        public void EnableLootBoxScreen()
        {
        
        }

        public void DisableLootBoxScreen()
        {
        
        }
    }
}
