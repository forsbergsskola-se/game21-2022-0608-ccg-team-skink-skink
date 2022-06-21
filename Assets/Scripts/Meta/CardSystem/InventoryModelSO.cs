using System.Collections.Generic;
using Meta.Interfaces;
using UnityEngine;

namespace Meta.CardSystem
{
    [CreateAssetMenu(fileName = "InventoryModel", menuName = "ScriptableObjects/CardSystem/Development/InventoryModel")]
    public class InventoryModelSO : ScriptableObject, IInventory
    {
        public List<ICard> Cards
        {
            get;
        } = new List<ICard>();
        
        public ICard SelectedCard
        {
            get;
            set;
        }
    }
}
