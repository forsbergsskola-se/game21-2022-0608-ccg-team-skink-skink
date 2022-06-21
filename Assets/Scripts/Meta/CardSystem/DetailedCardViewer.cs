using System;
using Meta.Interfaces;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Object = UnityEngine.Object;

namespace Meta.CardSystem
{
    public class CardViewer : MonoBehaviour
    {
        [SerializeField] private TMP_Text actionPointCostText;
        [SerializeField] private Sprite cardImage;
        [SerializeField] private TMP_Text description;
        [SerializeField] private TMP_Text levelText;
        [SerializeField] private TMP_Text nameText;
        
        [SerializeField, RequireInterface(typeof(IUIValueBar))] private Object attackBar;
        [SerializeField, RequireInterface(typeof(IUIValueBar))] private Object defenceBar;
        [SerializeField, RequireInterface(typeof(IUIValueBar))] private Object healthBar;
        [SerializeField, RequireInterface(typeof(IUIValueBar))] private Object speedBar;
        
        public IInventory Inventory { private get; set; }
        
        
        public void ViewCard()
        {
            var card = Inventory.SelectedCard;
            
            actionPointCostText.text = card.ApCost.ToString();
            cardImage = card.Image;
            description.text = card.Description;
            levelText.text = card.CardLevel.ToString();
            nameText.text = card.Name;
            
            // (attackBar as IUIValueBar).SetValue(/*TODO: Get value here*/);
            // (defenceBar as IUIValueBar).SetValue(/*TODO: Get value here*/);
            // (healthBar as IUIValueBar).SetValue(/*TODO: Get value here*/);
            // (speedBar as IUIValueBar).SetValue(/*TODO: Get value here*/);

            gameObject.SetActive(true);
        }

        public void StopView()
        {
            gameObject.SetActive(false);
        }
    }
}
