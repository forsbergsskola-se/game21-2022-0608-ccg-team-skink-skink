using System;
using Meta.Interfaces;
using UnityEngine;


namespace Meta.CardSystem
{
    public class CardHandViewer : MonoBehaviour
    {
        public ISettableCardHand CardHand;
        
        [SerializeField] private GameObject cardUIPrefab;
        private BasicCardViewer[] cardSlots;
        
        private BasicCardViewer lastSelectedCard;

        void Start()
        {
            CardHand.HandChanged += UpdateCardUI;
            CreateCardViewers();
            RefreshCardHand();
            CardHand.SelectedCardChanged += SetSelectedCardUI;
        }

        private void CreateCardViewers()
        {
            cardSlots = new BasicCardViewer[CardHand.Cards.Length];
            for (var i = 0; i < cardSlots.Length; i++)
            {
                var cardViewerObject = Instantiate(cardUIPrefab, transform);
                var basicCardViewer = cardViewerObject.GetComponent<BasicCardViewer>();
                cardSlots[i] = basicCardViewer;
            }
        }

        private void SetSelectedCardUI(ICard card, int index)
        {
            if (lastSelectedCard != null)
                lastSelectedCard.IsSelected = false;
            
            if (card == null)
                return;

            if (index < 0)
                throw new Exception("Selected card in hand does not actually exist in the hand.");
            
            cardSlots[index].IsSelected = true;
            lastSelectedCard = cardSlots[index];
        }
        
        private void UpdateCardUI(int index, ICard card)
        {
            cardSlots[index].SetCard(card);
        }

        private void RefreshCardHand()
        {
            for (var i = 0; i < cardSlots.Length; i++)
            {
                UpdateCardUI(i, CardHand[i]);
            }
        }
    }
}
