using System;
using Meta.Interfaces;
using UnityEngine;
using UnityEngine.UI;
using Utility;
using Object = UnityEngine.Object;

namespace Meta.CardSystem
{
    public class FuseCards : MonoBehaviour
    {
        [SerializeField, RequireInterface(typeof(ICardUpgradeScreen))] private Object cardUpgradeScreen;
        [SerializeField] Button upgradeButton;
        private IInventory inventory;

        void Awake()
        {
            inventory = Dependencies.Instance.Inventory;
        }

        private void Start()
        {
            inventory.SelectedCardChanged += ButtonControl;
        }

        public void ShowCardUpgradeScreen()
        {
            (cardUpgradeScreen as ICardUpgradeScreen).SetCard(inventory.SelectedCard);
        }
        
        private void ButtonControl(ICard card)
        {
            if (card?.UpgradedCard == null)
            {
                upgradeButton.interactable = false;
                return;
            }

            var selectedCardList = inventory.Cards[card.Id];
            upgradeButton.interactable = selectedCardList.Count >= 2;
        }

        public void Fuse()
        {
            //TODO: Bug that you can fuse, when the card is on the hand and you only have two.
            var cardToUpgrade = inventory.SelectedCard;
            for (int i = 0; i < 2; i++)
            {
                inventory.Remove(cardToUpgrade);
            }
            inventory.Add(cardToUpgrade.UpgradedCard);
            ButtonControl(inventory.SelectedCard);
            (cardUpgradeScreen as ICardUpgradeScreen).Hide();
        }
    }
}
