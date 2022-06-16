using System;
using Gameplay.AI.Unit.Behaviours;
using Gameplay.Unit;
using Gameplay.Unit.StatsInterfaces;
using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.Pool;

namespace Gameplay.AI.Unit
{
    public class UnitAI : MonoBehaviour
    {
        [Header("Dependencies")]
        [SerializeField] private MoveStats moveStats;
        
        private Movement movement;
        private Attack attack;
        private UnitState state;
        
        public string Target { get; set; }
        public Vector3 Direction { get; set; }

        private void Awake()
        {
            movement = new Movement(moveStats);
            attack = new Attack();

            state = UnitState.Moving;
        }

        private void FixedUpdate()
        {
            switch (state)
            {
                case UnitState.Moving:
                    movement.Move(this.transform, Direction);
                    
                    if (Physics.SphereCast(transform.position, 1, Direction, out RaycastHit hit, moveStats.Range) 
                        && hit.transform.CompareTag(Target))
                    {
                        state = UnitState.Attacking;
                    }
                    break;
                
                case UnitState.Attacking:
                    attack.Hit();
                    break;
            }
        }
    }
}
