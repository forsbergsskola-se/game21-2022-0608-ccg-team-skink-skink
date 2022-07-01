using Meta.CardSystem;
using Meta.Interfaces;
using UnityEngine;
using UnityEngine.Events;
using Object = UnityEngine.Object;


namespace Meta.LootBox
{
    public class LootBoxViewer : MonoBehaviour, ILootBoxViewer
    {
        public UnityEvent LootBoxOpen;
        
        [SerializeField, RequireInterface(typeof(ILootBoxInventoryModel))] private Object lootBoxInventoryModel;
        [SerializeField] BasicCardViewer[] basicCardViewers;
        [SerializeField] private GameObject viewContainer;

        void Awake()
        {
            (lootBoxInventoryModel as ILootBoxInventoryModel).LootBoxOpened += SetFromLootBox;
        }

        public void SetFromLootBox(ICard[] cards)
        {
            viewContainer.SetActive(true);
            
            LootBoxOpen.Invoke();
            
            //TODO: Play animation here
            
            //TODO: Call this method after animation is finished:
            ShowCards(cards);
        }
        
        public void Hide()
        {
            foreach (var basicCardViewer in basicCardViewers)
            {
                basicCardViewer.Reset();
            }
            viewContainer.SetActive(false);
        }

        private void ShowCards(ICard[] cards)
        {
            for (int i = 0; i < cards.Length; i++)
            {
                basicCardViewers[i].SetCard(cards[i]);
            }
        }
    }
}
