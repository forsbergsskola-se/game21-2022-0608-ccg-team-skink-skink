using System.Collections;
using System.Collections.Generic;
using Meta.Interfaces;
using UnityEngine;
using UnityEngine.UI;

namespace Gameplay.Unit
{
    public class UnitCoolDownTimer : MonoBehaviour
    {
        [Header("Dependencies")]
        [SerializeField, RequireInterface(typeof(ICardHand))] private Object deckHand;

        public void CoolDownUnit(int buttonId)
        {
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
