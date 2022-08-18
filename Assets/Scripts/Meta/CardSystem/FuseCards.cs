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
            inventory.CardRemoved += ButtonControl;
        }

        private void OnDestroy()
        {
            inventory.SelectedCardChanged -= ButtonControl;
            inventory.CardRemoved -= ButtonControl;
        }

        public void ShowCardUpgradeScreen()
        {
            (cardUpgradeScreen as ICardUpgradeScreen).SetCard(inventory.SelectedCard);
        }
        
        private void ButtonControl(ICard card)
        {
            if (card?.UpgradedCard == null || !inventory.Cards.ContainsKey(card.Id))
            {
                upgradeButton.interactable = false;
                return;
            }

            var selectedCardList = inventory.Cards[card.Id];
            upgradeButton.interactable = selectedCardList.Count >= 2;
        }

        public void Fuse()
        {
            if (inventory.SelectedCard.UpgradeCost > Dependencies.Instance.NormalCoinCarrier.Amount) return;
            
            var cardToUpgrade = inventory.SelectedCard;
            for (int i = 0; i < 2; i++)
            {
                inventory.Remove(cardToUpgrade);
            }
            Dependencies.Instance.NormalCoinCarrier.Amount -= inventory.SelectedCard.UpgradeCost;
            inventory.Add(cardToUpgrade.UpgradedCard);
            ButtonControl(inventory.SelectedCard);
            (cardUpgradeScreen as ICardUpgradeScreen).Hide();
        }
    }
}
