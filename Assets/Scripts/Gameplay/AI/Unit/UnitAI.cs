using System;
using Gameplay.AI.Unit.Behaviours;
using UnityEngine;

namespace Gameplay.AI.Unit
{
    public class UnitAI : MonoBehaviour
    {
        //Todo: move stats to another component
        [SerializeField] private float speed;
        [SerializeField] private Vector3 direction;
        
        private Movement movement;

        private void Awake()
        {
            movement = new Movement(speed, direction);
        }

        private void FixedUpdate()
        {
            movement.Move(this.transform);
        }
    }
}
