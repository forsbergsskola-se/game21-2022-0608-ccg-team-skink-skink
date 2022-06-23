using System.Collections;
using System.Collections.Generic;
using Meta.CardSystem;
using Meta.Interfaces;
using UnityEngine;

public class TemporaryInventoryUserInterface : MonoBehaviour
{
    public IInventory Inventory;

    [SerializeField, RequireInterface(typeof(ICard))] private Object card;

    public void Add()
    {
        Inventory.Add(card as ICard);
    }

    public void Remove()
    {
        Inventory.Remove(card as ICard);
    }
}
