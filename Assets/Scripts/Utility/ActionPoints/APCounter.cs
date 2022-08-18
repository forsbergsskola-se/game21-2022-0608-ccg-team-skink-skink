using System.Collections;
using Meta.Interfaces;
using UnityEngine;
using UnityEngine.Events;

namespace Utility.ActionPoints
{
    public class APCounter : MonoBehaviour
    {
        [SerializeField] private ActionPointsSO actionPoints;
        [SerializeField] private UnityEvent<uint, uint> onAPUpdate;
        [SerializeField] private UnityEvent<int> onAPSpent;
        
        private uint currentAP;
        private bool isUpdating;

        private ICardHand hand;
        
        private void Awake()
        {
            hand = Dependencies.Instance.PlayerCardHand;
            currentAP = actionPoints.Start;
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
            //Todo: Find a way to not let the button ID pass through ApCounter to UnitSpawner
            var apCost = hand.Cards[buttonId].ApCost;
            if (currentAP >= apCost)
            {
                StopAllCoroutines();
                PlayOneShot.PlayCardAudio();
                StartCoroutine(SubtractAP(apCost, buttonId));
            }
            else if (currentAP <= apCost)
            {
                PlayOneShot.InvalidInputAudio();
            }
        }
            
        private IEnumerator SubtractAP(int apCost, int buttonId)
        {
            isUpdating = true;

            currentAP -= (uint)apCost; //Todo: Check why we have to cast the apCost
            onAPUpdate.Invoke(currentAP, actionPoints.Max);
            onAPSpent.Invoke(buttonId);
            
            yield return new WaitForSeconds(actionPoints.Regen);
            
            isUpdating = false;

            yield return null;
        }
    }
}
