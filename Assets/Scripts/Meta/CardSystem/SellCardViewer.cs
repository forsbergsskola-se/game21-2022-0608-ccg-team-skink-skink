using System;
using System.Linq;
using Meta.Interfaces;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Utility;

namespace Meta.CardSystem
{
    public class SellCardViewer : MonoBehaviour, ISellCardScreen
    {
        [SerializeField] private Image cardImage;
        [SerializeField] private TMP_Text cardNameText;
        [SerializeField] private TMP_Text cardLevelText;
        [SerializeField] private TMP_Text singleCostText;
        [SerializeField] private TMP_Text allCostText;
        [SerializeField] private GameObject warningIndicator;

        private IInventory inventory;
        private ICardHand cardHand;

        public void SetViewFromCard(ICard card)
        {
            if (card == null)
            {
                Hide();
                return;
            }

            gameObject.SetActive(true);
            
            cardImage.sprite = card.CardImage;
            cardNameText.text = card.Name;
            cardLevelText.text = card.CardLevel.ToString();
            singleCostText.text = card.SellCost.ToString();
            allCostText.text = (card.SellCost * inventory.Cards[card.Id].Count).ToString();
            
            warningIndicator.SetActive(cardHand.Cards.Contains(card));
        }

        public void Hide()
        {
            gameObject.SetActive(false);
        }

        private void Awake()
        {
            inventory = Dependencies.Instance.Inventory;
            cardHand = Dependencies.Instance.PlayerCardHand;
        }

        private void Start()
        {
            inventory.CardRemoved += UpdateAllCost;
        }

        private void UpdateAllCost(ICard card)
        {
            if (RanOutOfCards(card))
            {
                SetViewFromCard(null);
                return;
            }
            
            allCostText.text = (card.SellCost * inventory.Cards[card.Id].Count).ToString();
        }

        private bool RanOutOfCards(ICard card)
        {
            return !inventory.Cards.ContainsKey(card.Id);
        }
    }
}
