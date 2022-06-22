using System;
using System.Collections;
using System.Collections.Generic;
using Meta.Interfaces;
using UnityEngine;
using UnityEngine.UI;
using Object = UnityEngine.Object;

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
        if (card == null)
            return;
        
        var selectedCardList = Inventory.Cards[card.Id];
        upgradeButton.interactable = selectedCardList.Count >= 2;
    }
}
