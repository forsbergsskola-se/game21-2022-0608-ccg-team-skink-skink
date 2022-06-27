using System;
using Meta.CardSystem;
using Meta.Interfaces;
using UnityEngine;
using Object = UnityEngine.Object;

namespace Meta.Development
{
    public class TemporaryPlayerCardHandCreator : MonoBehaviour
    {
        [SerializeField, RequireInterface(typeof(ICardHand))] private Object defaultCardHandSO;
        [SerializeField] private CardHandViewer cardHandViewer;

        private void Awake()
        {
            var defaultCardHand = defaultCardHandSO as ICardHand;
            var playerCardHand = new PlayerCardHand();

            cardHandViewer.CardHand = playerCardHand;
            
            // Adds the cards to the hand.
            for (int i = 0; i < playerCardHand.Cards.Length; i++)
            {
                playerCardHand[i] = defaultCardHand.Cards[i];
            }
        }
    }
}
