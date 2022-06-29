using Meta.Interfaces;
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
        //[SerializeField, RequireInterface(typeof(ICardHand))] private Object playerHand;
        [SerializeField] private Image[] cardImage;

        private ICardHand playerHand;
        
        private void Awake()
        {
            ICardHand hand = FindObjectOfType<Dependencies>().PlayerCardHand;
            
            for (int i = 0; i < buttons.Length; i++)
            {
                buttons[i].GetComponentInChildren<Text>().text = hand.Cards[i].Name;
                cardImage[i].sprite = hand.Cards[i].CardImage;
            }
        }
    }
}
