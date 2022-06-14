using System.Collections;
using UnityEngine;

namespace Gameplay.AI.Unit.Behaviours
{
    public class Movement
    {
        private float speed;
        
        public Movement(float speed) => this.speed = speed;
       
        public IEnumerator Move(Transform transform, Vector3 direction)
        {
            yield return transform.position += speed * direction;
        }
    }
}
