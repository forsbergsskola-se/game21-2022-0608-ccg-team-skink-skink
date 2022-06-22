using System.Collections;
using UnityEngine;
using UnityEngine.Events;

namespace Utility
{
    public class APCounter : MonoBehaviour
    {
        [SerializeField] private ActionPointsSO actionPoints;
        [SerializeField] private UnityEvent<uint, uint> onAPUpdate;
        private uint currentAP;
        private bool isUpdating;

        private void Awake() => currentAP = actionPoints.StartAP;
       
        private void FixedUpdate()
        {
            if (currentAP < actionPoints.MaxAP && !isUpdating)
            {
                isUpdating = true;
                StartCoroutine(UpdateAP());
            }
        }

        private IEnumerator UpdateAP()
        {
            while (isUpdating)
            {
                onAPUpdate.Invoke(++currentAP, actionPoints.MaxAP);
                if (currentAP == actionPoints.MaxAP) isUpdating = false;
            
                yield return new WaitForSeconds(actionPoints.APRegen);
            }

            yield return null;
        }
    }
}
