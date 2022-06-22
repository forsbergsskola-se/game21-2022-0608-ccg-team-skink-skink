using Meta.Interfaces;
using UnityEngine;
using UnityEngine.UI;

namespace Meta.CardSystem
{
    public class FuseCards : MonoBehaviour
    {
        [SerializeField, RequireInterface(typeof(ICardUpgradeScreen))] private Object cardUpgradeScreen;
        [SerializeField] Button upgradeButton;
        public IInventory Inventory;

        void Start()
        {
            Inventory.SelectedCardChanged += ButtonControl;
        }

        public void ShowCardUpgradeScreen()
        {
            (cardUpgradeScreen as ICardUpgradeScreen).SetCard(Inventory.SelectedCard);
        }
        
        private void ButtonControl(ICard card)
        {
            if (card?.UpgradedCard == null)
            {
                upgradeButton.interactable = false;
                return;
            }

            var selectedCardList = Inventory.Cards[card.Id];
            upgradeButton.interactable = selectedCardList.Count >= 2;
        }

        public void Fuse()
        {
            var cardToUpgrade = Inventory.SelectedCard;
            for (int i = 0; i < 2; i++)
            {
                Inventory.Remove(cardToUpgrade);
            }
            Inventory.Add(cardToUpgrade.UpgradedCard);
            ButtonControl(cardToUpgrade);
            (cardUpgradeScreen as ICardUpgradeScreen).Hide();
        }
    }
}
