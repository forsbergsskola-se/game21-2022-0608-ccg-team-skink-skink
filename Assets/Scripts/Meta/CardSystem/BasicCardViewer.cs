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
        [SerializeField] private Image typeImage;
        [SerializeField] private Image cardBackground;

        public ICard Card { get; private set; }
        private int stackSize = 1;

        public int StackSize
        {
            get => stackSize;
            set
            {
                stackSize = value;
                stackSizeText.text = stackSize > 1 ? $"X{stackSize}" : "";
            }
        }


        private bool isSelected;
        
        public bool IsSelected
        {
            set
            {
                isSelected = value;
                cardBackground.color = isSelected ? Color.blue : Color.white;
            }
        }
        
        public void SetCard(ICard card)
        {
            gameObject.SetActive(true);
            actionPointCostText.text = card.ApCost.ToString();
            cardImage.sprite = card.CardImage;
            typeImage.sprite = card.TypeImage;
            Card = card;
        }

        public void Reset()
        {
            stackSize = 1;
            stackSizeText.text = "";
            gameObject.SetActive(false);
            Card = null;
        }
    }
}
