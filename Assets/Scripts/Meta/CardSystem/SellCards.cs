using System;
using Meta.Interfaces;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using Utility;


namespace Meta.CardSystem
{
    public class SellCards : MonoBehaviour
    {
        [SerializeField] Button sellButton;
        
        private IInventory Inventory;
        private INormalCoinCarrier NormalCoinCarrier;

        [SerializeField]int sellPrice = 100;

        void Awake()
        {
            Inventory = Dependencies.Instance.Inventory;
            NormalCoinCarrier = Dependencies.Instance.NormalCoinCarrier;
        }

        void Start()
        {
            Inventory.CardRemoved += ButtonControl;
            Inventory.CardAdded += ButtonControl;
        }

        public void SellCard()
        {
            NormalCoinCarrier.Amount += sellPrice*Inventory.SelectedCard.CardLevel;
            Inventory.Remove(Inventory.SelectedCard);
        }
        public void SellAllCards()
        {
            
        }

        private void ButtonControl(ICard card)
        {
            sellButton.interactable = Inventory.Cards.Count > 6;
        }
    }
}
