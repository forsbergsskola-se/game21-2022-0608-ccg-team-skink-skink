using Meta.Interfaces;
using UnityEngine;


namespace Meta.CardSystem
{
    public class CardHandViewer : MonoBehaviour
    {
        public ISettableCardHand CardHand;
        
        [SerializeField] private GameObject cardUIPrefab;
        private BasicCardViewer[] cardSlots;
        

        void Start()
        {
            CardHand.HandChanged += UpdateCardUI;
            CreateCardViewers();
            RefreshCardHand();
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
