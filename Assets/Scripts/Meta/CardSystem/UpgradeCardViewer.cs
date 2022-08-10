using Meta.Interfaces;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Utility;


namespace Meta.CardSystem
{
    public class UpgradeCardViewer : MonoBehaviour, ICardUpgradeScreen
    {
        [SerializeField] Image[] baseCardImages = new Image[2];
        [SerializeField] Image resultCardImage;

        [SerializeField] private TMP_Text upgradeCostText;
        [SerializeField] private GameObject insufficientFundsWarningObject;
        
        // [SerializeField, RequireInterface(typeof(IUIValueBar))] private Object attackBar;
        // [SerializeField, RequireInterface(typeof(IUIValueBar))] private Object defenceBar;
        // [SerializeField, RequireInterface(typeof(IUIValueBar))] private Object healthBar;
        // [SerializeField, RequireInterface(typeof(IUIValueBar))] private Object speedBar;
        //
        // [SerializeField, RequireInterface(typeof(IUIValueBar))] private Object resultCardAttackBar;
        // [SerializeField, RequireInterface(typeof(IUIValueBar))] private Object resultCardDefenceBar;
        // [SerializeField, RequireInterface(typeof(IUIValueBar))] private Object resultCardHealthBar;
        // [SerializeField, RequireInterface(typeof(IUIValueBar))] private Object resultCardSpeedBar;
        public void SetCard(ICard cardToUpgrade)
        {
            gameObject.SetActive(true);

            foreach (var image in baseCardImages)
                image.sprite = cardToUpgrade.CardImage;

            resultCardImage.sprite = cardToUpgrade.UpgradedCard.CardImage;

            upgradeCostText.text = cardToUpgrade.UpgradeCost.ToString();
            
            insufficientFundsWarningObject.SetActive(Dependencies.Instance.NormalCoinCarrier.Amount < cardToUpgrade.UpgradeCost);

            // (attackBar as IUIValueBar).SetValue(/*TODO: Get value here*/);
            // (defenceBar as IUIValueBar).SetValue(/*TODO: Get value here*/);
            // (healthBar as IUIValueBar).SetValue(/*TODO: Get value here*/);
            // (speedBar as IUIValueBar).SetValue(/*TODO: Get value here*/);

            // (resultCardAttackBar as IUIValueBar).SetValue(/*TODO: Get value here*/);
            // (resultCardDefenceBar as IUIValueBar).SetValue(/*TODO: Get value here*/);
            // (resultCardHealthBar as IUIValueBar).SetValue(/*TODO: Get value here*/);
            // (resultCardSpeedBar as IUIValueBar).SetValue(/*TODO: Get value here*/);

        }

        public void Hide()
        {
            gameObject.SetActive(false);
        }
    }
}
