using System.Collections;
using Meta.Interfaces;
using UnityEngine;
using UnityEngine.UI;
using Utility;

namespace Gameplay.Unit.UnitUtility
{
    public class UnitCoolDownTimer : MonoBehaviour
    {
        [SerializeField] private sbyte animationFramerate = 30;
        
        private ICardHand deckHand;
        private float frameTime;

        
        private void Start()
        {
            frameTime = 1 / (float)animationFramerate;
            deckHand = Dependencies.Instance.PlayerCardHand;
        }
        
        
        public void CoolDownUnit(int buttonId)
        {
            GameObject clickedButtonGO = UnityEngine.EventSystems.EventSystem.current.currentSelectedGameObject;
            StartCoroutine(CardAnimation(clickedButtonGO, deckHand.Cards[buttonId].CoolDownTime));
        }
        
        
        private IEnumerator CardAnimation(GameObject cardObject, int coolDown)
        {
            cardObject.GetComponent<Button>().interactable = false;
            
            var cardTransform = cardObject.GetComponent<RectTransform>();
            var startPos = cardTransform.anchoredPosition;
            var height = cardTransform.rect.height;
            var stepSize = 1f / (coolDown * animationFramerate);
            var xPos = startPos.x;

            // Animation and timer.
            float time = 1;
            do
            {
                var yPos = startPos.y + (height*0.75f) * AnimationFormula(time, coolDown * 4);
                cardTransform.anchoredPosition = new Vector2(xPos, yPos);
                time -= stepSize;
                yield return new WaitForSeconds(frameTime);
            } while (time > 0);

            cardTransform.anchoredPosition = startPos;
            PlayOneShot.ActivateCardAudio();
            cardObject.GetComponent<Button>().interactable = true;
        }


        /// <summary>
        /// Returns a float to be used as a multiplier for changing card height.
        /// </summary>
        /// <param name="x">Any value between 1 - 0 for start to end of animation.</param>
        /// <param name="fallSpeed">The speed of the initial bounce up and fall down.</param>
        /// <returns></returns>
        private float AnimationFormula(float x, float fallSpeed)
        {
            return Mathf.Sin(2.2f * Mathf.Pow(x, fallSpeed + 5.9f)) - x + 0.15f * Mathf.Pow(x, 4);
        }
    }
    
}
