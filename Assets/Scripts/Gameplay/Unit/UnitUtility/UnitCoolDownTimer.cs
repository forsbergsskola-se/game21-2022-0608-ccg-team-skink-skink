using System;
using System.Collections;
using Meta.Interfaces;
using UnityEngine;
using UnityEngine.UI;
using Utility;

namespace Gameplay.Unit.UnitUtility
{
    public class UnitCoolDownTimer : MonoBehaviour
    {
        private ICardHand deckHand; // Changed to Dependency Injection
        [SerializeField] private sbyte animationFramerate = 30;
        private float frameTime;

        private void Start()
        {
            frameTime = 1 / (float)animationFramerate;
        }

        public void CoolDownUnit(int buttonId)
        {
            deckHand = FindObjectOfType<Dependencies>().PlayerCardHand;
            
            GameObject clickedButtonGO = UnityEngine.EventSystems.EventSystem.current.currentSelectedGameObject;
            ICardHand hand = deckHand as ICardHand;
            // StartCoroutine(UnitCoolDown(clickedButtonGO, hand.Cards[buttonId].CoolDownTime));
            StartCoroutine(CardAnimation(clickedButtonGO, hand.Cards[buttonId].CoolDownTime));
        }
        
        // private IEnumerator UnitCoolDown(GameObject cardButton,int coolDownTime)
        // {
        //     cardButton.GetComponent<Button>().enabled = false;
        //     CardAnimation(cardButton, coolDownTime);
        //     //TODO: Animation + sound (in a separated script ??)
        //     yield return new WaitForSeconds(coolDownTime);
        //     PlayOneShot.ActivateCardAudio();
        //     cardButton.GetComponent<Button>().enabled = true;
        // }
        
        

        private IEnumerator CardAnimation(GameObject cardObject, int coolDown)
        {
            cardObject.GetComponent<Button>().interactable = false;
            
            var transform = cardObject.GetComponent<RectTransform>();
            var startPos = transform.anchoredPosition;
            var height = transform.rect.height;
            var stepSize = 1f / (coolDown * animationFramerate);
            var xPos = startPos.x;
            var yPos = startPos.y;

            // Debug.Log($"Transform: {transform}, startPos: {startPos}, height: {height}, stepSize: {stepSize}");

            float time = 1;
            do
            {
                yPos = startPos.y + (height*0.75f) * AnimationFormula(time, coolDown * 4);
                transform.anchoredPosition = new Vector2(xPos, yPos);
                time -= stepSize;
                yield return new WaitForSeconds(frameTime);
                // Debug.Log($"time = {time}");

            } while (time > 0);

            transform.anchoredPosition = startPos;
            PlayOneShot.ActivateCardAudio();
            cardObject.GetComponent<Button>().interactable = true;
        }

        /// <summary>
        /// Returns a float to be used as a multiplier for changing card height.
        /// </summary>
        /// <param name="x">Any value between 1 - 0 for start to end of animation.</param>
        /// <returns></returns>
        private float AnimationFormula(float x, float fallSpeed)
        {
            return Mathf.Sin(2.2f * Mathf.Pow(x, fallSpeed + 5.9f)) - x + 0.15f * Mathf.Pow(x, 4);
        }
    }
    
}
