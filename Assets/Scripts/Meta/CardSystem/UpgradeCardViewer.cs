using Gameplay.Unit.Ai;
using Gameplay.Unit.Health;
using Meta.Interfaces;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Utility;


namespace Meta.CardSystem
{
    /// <summary>
    /// This class is a nightmare to look at. Open at your own risk.
    /// </summary>
    public class UpgradeCardViewer : MonoBehaviour, ICardUpgradeScreen
    {
        [SerializeField] Image[] baseCardImages = new Image[2];
        [SerializeField] Image resultCardImage;

        [SerializeField] private TMP_Text upgradeCostText;
        [SerializeField] private GameObject insufficientFundsWarningObject;
        
        [SerializeField, RequireInterface(typeof(IUIValueBar))] private Object attackBar;
        [SerializeField, RequireInterface(typeof(IUIValueBar))] private Object defenceBar;
        [SerializeField, RequireInterface(typeof(IUIValueBar))] private Object healthBar;
        [SerializeField, RequireInterface(typeof(IUIValueBar))] private Object speedBar;
        
        [SerializeField, RequireInterface(typeof(IUIValueBar))] private Object resultCardAttackBar;
        [SerializeField, RequireInterface(typeof(IUIValueBar))] private Object resultCardDefenceBar;
        [SerializeField, RequireInterface(typeof(IUIValueBar))] private Object resultCardHealthBar;
        [SerializeField, RequireInterface(typeof(IUIValueBar))] private Object resultCardSpeedBar;
        
        public void SetCard(ICard cardToUpgrade)
        {
            gameObject.SetActive(true);

            foreach (var image in baseCardImages)
                image.sprite = cardToUpgrade.CardImage;

            resultCardImage.sprite = cardToUpgrade.UpgradedCard.CardImage;

            upgradeCostText.text = cardToUpgrade.UpgradeCost.ToString();

            insufficientFundsWarningObject.SetActive(Dependencies.Instance.NormalCoinCarrier.Amount < cardToUpgrade.UpgradeCost);

            (attackBar as IUIValueBar).SetValue(cardToUpgrade.CardObject.GetComponent<UnitAI>().CombatStats.Damage);
            (defenceBar as IUIValueBar).SetValue(cardToUpgrade.CardObject.GetComponent<UnitAI>().CombatStats.Defence);
            (healthBar as IUIValueBar).SetValue(cardToUpgrade.CardObject.GetComponent<HealthComponent>().HealthStats.MaxHealth);
            (speedBar as IUIValueBar).SetValue(cardToUpgrade.CardObject.GetComponent<UnitAI>().CombatStats.AttackSpeed);

            (resultCardAttackBar as IUIValueBar).SetValue(cardToUpgrade.UpgradedCard.CardObject.GetComponent<UnitAI>().CombatStats.Damage);
            (resultCardDefenceBar as IUIValueBar).SetValue(cardToUpgrade.UpgradedCard.CardObject.GetComponent<UnitAI>().CombatStats.Defence);
            (resultCardHealthBar as IUIValueBar).SetValue(cardToUpgrade.UpgradedCard.CardObject.GetComponent<HealthComponent>().HealthStats.MaxHealth);
            (resultCardSpeedBar as IUIValueBar).SetValue(cardToUpgrade.UpgradedCard.CardObject.GetComponent<UnitAI>().CombatStats.AttackSpeed);

        }

        public void Hide()
        {
            gameObject.SetActive(false);
        }
    }
}
