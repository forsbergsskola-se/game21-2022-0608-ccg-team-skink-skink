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
        private Attack attack;

        private void Awake()
        {
            movement = new Movement(stats.Speed, stats.Direction);
            attack = new Attack();
        }
            
        private void FixedUpdate()
        {
            if (Physics.SphereCast(transform.position, 1, stats.Direction, out RaycastHit hit, stats.Range) 
                && hit.transform.CompareTag("Enemy"))
            {
                
                StartCoroutine(attack.Hit());   
                
            }
            else StartCoroutine(movement.Move(this.transform));
        }
    }
}
