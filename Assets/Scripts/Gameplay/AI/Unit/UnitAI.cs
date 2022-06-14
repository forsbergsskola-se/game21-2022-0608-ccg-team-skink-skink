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
        [SerializeField] private float range;
        
        private Movement movement;

        private void Awake() 
            => movement = new Movement(speed, direction);

        private void FixedUpdate()
        {
            RaycastHit hit;
            
            if(Physics.SphereCast(transform.position, 1, direction,out hit, range))
            {
                
            } 
            else StartCoroutine(movement.Move(this.transform));
        } 
           
    }
}
