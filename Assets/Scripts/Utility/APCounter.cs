using System.Collections;
using Meta.Interfaces;
using UnityEngine;
using UnityEngine.Events;

namespace Utility
{
    public class APCounter : MonoBehaviour
    {
        [SerializeField] private ActionPointsSO actionPoints;
        [SerializeField, RequireInterface(typeof(ICardHand))] private Object playerHand;
        [SerializeField] private UnityEvent<uint, uint> onAPUpdate;
        [SerializeField] private UnityEvent<int> onAPSpent;
        
        private uint currentAP;
        private bool isUpdating;

        private ICardHand hand;
        
        private void Awake()
        {
            currentAP = actionPoints.Start;
            hand = playerHand as ICardHand;
        } 
       
        private void FixedUpdate()
        {
            if (currentAP < actionPoints.Max && !isUpdating)
            {
                isUpdating = true;
                StartCoroutine(UpdateAP());
            }
        }

        private IEnumerator UpdateAP()
        {
            while (isUpdating)
            {
                onAPUpdate.Invoke(++currentAP, actionPoints.Max);
                if (currentAP == actionPoints.Max) isUpdating = false;
            
                yield return new WaitForSeconds(actionPoints.Regen);
            }

            yield return null;
        }

        public void SpendAP(int buttonId)
        {
            var apCost = hand.Cards[buttonId].ApCost;
            if (currentAP >= apCost)
            {
                StopAllCoroutines();
                
                StartCoroutine(SubtractAP(apCost, buttonId));
            }
        }
            
        private IEnumerator SubtractAP(int apCost, int buttonId)
        {
            isUpdating = true;

            currentAP -= (uint)apCost;
            onAPUpdate.Invoke(currentAP, actionPoints.Max);
            onAPSpent.Invoke(buttonId);
            
            yield return new WaitForSeconds(actionPoints.Regen);
            
            isUpdating = false;

            yield return null;
        }
    }
}
