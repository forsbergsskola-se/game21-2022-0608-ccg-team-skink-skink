using System;
using Meta.Interfaces;
using UnityEngine;
namespace Meta.CardSystem
{
    public class CardHandViewer : MonoBehaviour
    {
        public ISettableCardHand CardHand;
        BasicCardViewer[] cardSlots;
        [SerializeField] private GameObject cardUIPrefab;

        void Start()
        {
            CreateCardViewers();
            // CardHand.HandChanged += UpdateCardUI;
        }

        public void CreateCardViewers()
        {
            cardSlots = new BasicCardViewer[CardHand.Cards.Length];
            for (int i = 0; i < cardSlots.Length; i++)
            {
                var cardViewerObject = Instantiate(cardUIPrefab, transform);
                var basicCardViewer = cardViewerObject.GetComponent<BasicCardViewer>();
                cardSlots[i] = basicCardViewer;
            }
        }
        private void UpdateCardUI(int index, ICard card)
        {
            cardSlots[index].SetCard(card);
        }
    }
}
