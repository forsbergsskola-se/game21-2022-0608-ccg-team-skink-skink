using System.Collections;
using UnityEngine;

namespace Gameplay.AI.Unit.Behaviours
{
    public class Attack 
    {
        public IEnumerator Hit()
        {
            Debug.Log("I am Attacking!!!!");
            yield return null;
        }
    }
}
