using Meta.Interfaces;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
namespace Meta.CardSystem
{
    public class BasicCardViewer : MonoBehaviour
    {
        [SerializeField] private TMP_Text actionPointCostText;
        [SerializeField] private Image cardImage;
        [SerializeField] private TMP_Text stackSizeText;
        private int stackSize = 1;

        public int StackSize
        {
            get => stackSize;
            set
            {
                stackSize = value;
                stackSizeText.text = $"X{stackSize}";
            }
        }
        public void SetCard(ICard card)
        {
            actionPointCostText.text = card.ApCost.ToString();
            cardImage.sprite = card.Image;
            stackSizeText.text = StackSize.ToString();
        }
    }
}
