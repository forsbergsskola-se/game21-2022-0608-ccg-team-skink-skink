using System;
using Meta.Interfaces;
using UnityEngine;
using UnityEngine.UI;
using Utility;
namespace Meta.CardSystem
{
    public class DetailedCardViewButtonController : MonoBehaviour
    {
        [SerializeField] Button detailCardViewButton;
        
        private IInventory inventory;

        void Awake()
        {
            inventory = Dependencies.Instance.Inventory;
        }

        void OnEnable()
        {
            inventory.SelectedCardChanged += ButtonControl;
        }
        void OnDisable()
        {
            inventory.SelectedCardChanged -= ButtonControl;
        }

        void ButtonControl(ICard card)
        {
            detailCardViewButton.interactable = card != null;
        }
    }
}
