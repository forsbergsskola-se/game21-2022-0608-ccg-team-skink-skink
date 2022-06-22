using System;
using Meta.Interfaces;
using UnityEngine;

namespace Meta.CardSystem
{
    public class InteractableCard : MonoBehaviour
    {
        public event Action<ICard> CardClicked;
        [SerializeField] BasicCardViewer basicCardViewer;

        public void TriggerClickedCardEvent()
        {
            CardClicked?.Invoke(basicCardViewer.Card);
        }
    }
}
