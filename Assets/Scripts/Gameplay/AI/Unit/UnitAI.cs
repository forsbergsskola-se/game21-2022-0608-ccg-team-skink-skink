using System;
using Gameplay.AI.Unit.Behaviours;
using Gameplay.Unit;
using UnityEngine;

namespace Gameplay.AI.Unit
{
    public class UnitAI : MonoBehaviour
    {
        [Header("Dependencies")]
        [SerializeField] private Stats stats;
        
        private Movement movement;

        private void Awake() 
            => movement = new Movement(stats.Speed, stats.Direction);

        private void FixedUpdate()
        {
            RaycastHit hit;
            
            if(Physics.SphereCast(transform.position, 1, stats.Direction,out hit, stats.Range))
            {
                
            } 
            else StartCoroutine(movement.Move(this.transform));
        } 
           
    }
}
