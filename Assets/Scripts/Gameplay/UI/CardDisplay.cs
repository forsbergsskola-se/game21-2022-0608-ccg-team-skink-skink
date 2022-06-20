using Meta.Interfaces;
using UnityEngine;
using UnityEngine.UI;
using Object = UnityEngine.Object;

namespace Gameplay.UI
{
    public class CardDisplay : MonoBehaviour
    {
        [Header("Dependencies")]
        [SerializeField] private Button[] buttons;
        [SerializeField, RequireInterface(typeof(ICardHand))] private Object playerHand;
        
        private void Awake()
        {
            ICardHand hand = playerHand as ICardHand;
            
            for (int i = 0; i < buttons.Length; i++)
            {
                buttons[i].GetComponentInChildren<Text>().text = hand.Cards[i].Name;
                buttons[i].GetComponentInChildren<Image>().sprite = hand.Cards[i].Image;
            }
        }
    }
}
