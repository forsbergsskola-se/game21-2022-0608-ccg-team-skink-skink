using System;
using Gameplay.Unit;
using Gameplay.Unit.Ai;
using Gameplay.Unit.Health;
using Meta.GenericUIScripts;
using Meta.Interfaces;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Utility;
using Object = UnityEngine.Object;

namespace Meta.CardSystem
{
    public class DetailedCardViewer : MonoBehaviour
    {
        //[SerializeField] private TMP_Text actionPointCostText;
        [SerializeField] private Image cardImage;
        [SerializeField] private TMP_Text description;
        [SerializeField] private TMP_Text levelText;
        [SerializeField] private TMP_Text nameText;
        
        [SerializeField, RequireInterface(typeof(IUIValueBar))] private Object attackBar;
        [SerializeField, RequireInterface(typeof(IUIValueBar))] private Object defenceBar;
        [SerializeField, RequireInterface(typeof(IUIValueBar))] private Object healthBar;
        [SerializeField, RequireInterface(typeof(IUIValueBar))] private Object speedBar;
        

        private IInventory inventory;

        void Awake()
        {
            inventory = Dependencies.Instance.Inventory;
        }


        public void ViewCard()
        {
            gameObject.SetActive(true);
            var card = inventory.SelectedCard;
            
            //TODO:Remove???
            //actionPointCostText.text = card.ApCost.ToString();
            cardImage.sprite = card.CardImage;
            description.text = card.Description;
            levelText.text = card.CardLevel.ToString();
            nameText.text = card.Name;
            
            (attackBar as IUIValueBar).SetValue(card.CardObject.GetComponent<UnitAI>().CombatStats.Damage);
            (defenceBar as IUIValueBar).SetValue(card.CardObject.GetComponent<UnitAI>().CombatStats.Defence);
            (healthBar as IUIValueBar).SetValue(card.CardObject.GetComponent<HealthComponent>().HealthStats.MaxHealth);
            (speedBar as IUIValueBar).SetValue(card.CardObject.GetComponent<UnitAI>().CombatStats.AttackSpeed);
            
        }

        public void StopView()
        {
            gameObject.SetActive(false);
        }
    }
}
