using System;
using Meta.Interfaces;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Utility;
using Object = UnityEngine.Object;

namespace Gameplay.UI
{
    public class CardDisplay : MonoBehaviour
    {
        [Header("Dependencies")]
        [SerializeField] private Button[] buttons;
        [SerializeField] private Image[] cardImage;
        [SerializeField] private Text[] apCosts;

        private ICardHand playerHand;
        
        private void Awake() => playerHand = Dependencies.Instance.PlayerCardHand;
        
        private void Start()
        {
            for (int i = 0; i < buttons.Length; i++)
            {
                buttons[i].GetComponentInChildren<Text>().text = playerHand.Cards[i].Name;
                cardImage[i].sprite = playerHand.Cards[i].CardImage;
                apCosts[i].text = playerHand.Cards[i].ApCost.ToString();
            }
        }
    }
}
