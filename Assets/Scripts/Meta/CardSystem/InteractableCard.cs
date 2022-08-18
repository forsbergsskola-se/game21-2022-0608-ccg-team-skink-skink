using System;
using Meta.Interfaces;
using UnityEngine;

namespace Meta.CardSystem
{
    public class InteractableCard : MonoBehaviour
    {
        public event Action<ICard> CardClicked;
        [SerializeField] BasicCardViewer basicCardViewer;

        private void Awake()
        {
            var receivers = transform.parent.gameObject.GetComponents<ICardReceiver>();
            foreach (var cardReceiver in receivers)
            {
                CardClicked += cardReceiver.ReceiveCard;
            }
        }

        private void OnDestroy()
        {
            var receivers = transform.parent.gameObject.GetComponents<ICardReceiver>();
            foreach (var cardReceiver in receivers)
            {
                CardClicked -= cardReceiver.ReceiveCard;
            }
        }

        public void TriggerClickedCardEvent()
        {
            CardClicked?.Invoke(basicCardViewer.Card);
        }
    }
}
