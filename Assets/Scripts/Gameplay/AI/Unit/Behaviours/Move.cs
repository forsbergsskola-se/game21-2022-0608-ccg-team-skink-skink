using System.Collections;
using UnityEngine;

namespace Gameplay.AI.Unit.Behaviours
{
    public class Movement
    {
        private float speed;
        private Vector3 direction;

        public Movement(float speed, Vector3 direction)
        {
            this.speed = speed;
            this.direction = direction;
        }

        public void Move(Transform transform) 
            => transform.position += speed * direction;
    }
}
