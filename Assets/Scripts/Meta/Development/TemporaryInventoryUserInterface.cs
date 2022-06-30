using System;
using Meta.Interfaces;
using UnityEngine;
using Utility;
using Object = UnityEngine.Object;

public class TemporaryInventoryUserInterface : MonoBehaviour
{
    private IInventory inventory;

    [SerializeField, RequireInterface(typeof(ICard))] private Object card;

    private void Awake()
    {
        inventory = Dependencies.Instance.Inventory;
    }

    public void Add()
    {
        inventory.Add(card as ICard);
    }

    public void Remove()
    {
        inventory.Remove(card as ICard);
    }
}
