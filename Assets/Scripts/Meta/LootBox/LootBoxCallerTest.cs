using UnityEngine;
using Utility;

namespace Meta.LootBox
{
    public class LootBoxCallerTest : MonoBehaviour
    {
        [SerializeField] private CardsTierSO cards;

        private void Start()
        {
            Dependencies.Instance.LootBoxSystem.CreateNewLootBox();
            var loot = Dependencies.Instance.LootBoxSystem.OpenLootBox(cards, 5);

            foreach (var card in loot)
            {
                Debug.Log(card.Name);
            }
            
            Debug.Log(Dependencies.Instance.Inventory.Cards.Count);
            
        }
    }
}
