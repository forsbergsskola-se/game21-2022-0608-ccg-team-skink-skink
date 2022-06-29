using Meta.Interfaces;
using UnityEngine;
using UnityEngine.UI;
using Utility;
using Object = UnityEngine.Object;


namespace Meta.CardSystem
{
    public class SellCards : MonoBehaviour
    {
        [SerializeField] Button sellButton;

        [SerializeField, RequireInterface(typeof(ISellCardScreen))] private Object sellCardScreen;
        
        private IInventory Inventory;
        private INormalCoinCarrier NormalCoinCarrier;

        void Awake()
        {
            Inventory = Dependencies.Instance.Inventory;
            NormalCoinCarrier = Dependencies.Instance.NormalCoinCarrier;
        }

        void Start()
        {
            Inventory.SelectedCardChanged += ButtonControl;
            Inventory.CardRemoved += ButtonControl;
            Inventory.CardAdded += ButtonControl;
        }

        public void ShowSellCardScreen()
        {
            (sellCardScreen as ISellCardScreen).SetViewFromCard(Inventory.SelectedCard);
        }

        public void SellCard()
        {
            NormalCoinCarrier.Amount += Inventory.SelectedCard.SellCost;
            Inventory.Remove(Inventory.SelectedCard);
        }
        
        public void SellAllCards()
        {
            // This is here since the count changes while we sell it, so we cache the value before starting.
            var amountToSell = Inventory.Cards[Inventory.SelectedCard.Id].Count;
            for (var index = 0; index < amountToSell; index++)
            {
                SellCard();
            }
        }

        private void ButtonControl(ICard card)
        {
            sellButton.interactable = Inventory.Cards.Count > 6;
        }
    }
}
