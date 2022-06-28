using System.Collections;
using System.Collections.Generic;
using Meta.Interfaces;
using UnityEngine;
using UnityEngine.UI;
using Utility;

namespace Gameplay.Unit
{
    public class UnitCoolDownTimer : MonoBehaviour
    {
        private ICardHand deckHand; // Changed to Dependency Injection

        public void CoolDownUnit(int buttonId)
        {
            deckHand = FindObjectOfType<Dependencies>().PlayerCardHand;
            
            GameObject clickedButtonGO = UnityEngine.EventSystems.EventSystem.current.currentSelectedGameObject;
            ICardHand hand = deckHand as ICardHand;
            StartCoroutine(UnitCoolDown(clickedButtonGO, hand.Cards[buttonId].CoolDownTime));
        }
        
        private IEnumerator UnitCoolDown(GameObject cardButton,int coolDownTime)
        {
            cardButton.GetComponent<Button>().enabled = false;
            //TODO: Animation + sound (in a separated script ??)
            yield return new WaitForSeconds(coolDownTime);
            cardButton.GetComponent<Button>().enabled = true;
        }
    }
    
}
