using System;
using Meta.Interfaces;
using UnityEngine;
using UnityEngine.UI;
using Utility;
using Object = UnityEngine.Object;


namespace Meta.CardSystem
{
    public class SellCards : MonoBehaviour
    {
        [SerializeField] Button openSellMenuButton;
        [SerializeField] Button sellAllButton;

        [SerializeField, RequireInterface(typeof(ISellCardScreen))] private Object sellCardScreen;
        
        private IInventory Inventory;
        private INormalCoinCarrier NormalCoinCarrier;

        void Awake()
        {
            Inventory = Dependencies.Instance.Inventory;
            NormalCoinCarrier = Dependencies.Instance.NormalCoinCarrier;
        }

        void Start()
        {
            Inventory.SelectedCardChanged += ButtonControl;
            Inventory.CardRemoved += ButtonControl;
            Inventory.CardAdded += ButtonControl;
        }

        private void OnDestroy()
        {
            Inventory.SelectedCardChanged -= ButtonControl;
            Inventory.CardRemoved -= ButtonControl;
            Inventory.CardAdded -= ButtonControl;
        }

        public void ShowSellCardScreen()
        {
            sellAllButton.interactable = Inventory.Cards.Count > 6;
            Inventory.CardRemoved += UpdateSellButtonAvailability;
            (sellCardScreen as ISellCardScreen).SetViewFromCard(Inventory.SelectedCard);
        }

        public void SellCard()
        {
            NormalCoinCarrier.Amount += Inventory.SelectedCard.SellCost;
            Inventory.Remove(Inventory.SelectedCard);
            
        }
        
        public void SellAllCards()
        {
            // This is here since the count changes while we sell it, so we cache the value before starting.
            var amountToSell = Inventory.Cards[Inventory.SelectedCard.Id].Count;
            for (var index = 0; index < amountToSell; index++)
            {
                SellCard();
            }
        }
        private void UpdateSellButtonAvailability(ICard card)
        {
            
            if (!Inventory.Cards.ContainsKey(card.Id))
            {
                (sellCardScreen as ISellCardScreen).SetViewFromCard(null);
                Inventory.CardRemoved -= UpdateSellButtonAvailability;
                return;
            }
            if (Inventory.Cards.Count <= 6)
            {
                if (Inventory.Cards[card.Id].Count <= 1)
                {
                    (sellCardScreen as ISellCardScreen).SetViewFromCard(null);
                    Inventory.CardRemoved -= UpdateSellButtonAvailability;
                    return;
                }
            }
        }

        private void ButtonControl(ICard card)
        {
            if (Inventory.SelectedCard == null)
            {
                openSellMenuButton.interactable = false;
                return;
            }
            if (Inventory.Cards.Count > 6)
            {
                openSellMenuButton.interactable = true;
                return;
            }
            if (Inventory.Cards[Inventory.SelectedCard.Id].Count > 1)
            {
                openSellMenuButton.interactable = true;
                return;
            }
            openSellMenuButton.interactable = false;
        }
    }
}
