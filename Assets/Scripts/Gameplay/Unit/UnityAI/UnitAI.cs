using System;
using Gameplay.Unit.Health;
using Gameplay.Unit.UnitActions;
using JetBrains.Annotations;
using Unity.VisualScripting;
using UnityEngine;

namespace Gameplay.Unit.UnityAI
{
    [RequireComponent(typeof(BoxCollider))]
    public class UnitAI : MonoBehaviour, IUnit
    {
        [Header("Dependencies")]
        [SerializeField] private MoveStats moveStats;
        [SerializeField] private CombatStats combatStats;
        
        private Movement movement;
        private Attack attack;
        private UnitState state;
        
        public string Target { get; set; }
        public Vector3 Direction { get; set; }
        
        private void Awake()
        {
            movement = new Movement(moveStats);
            attack = new Attack(combatStats);

            state = UnitState.Moving;

            SetRange();
        }

        private void FixedUpdate()
        {
            if(state == UnitState.Moving) movement.Move(transform, Direction);
        }

        private void OnTriggerEnter(Collider other)
        {
            if (state != UnitState.Action && !other.gameObject.CompareTag(gameObject.tag))
            {
                var damageReceiver = other.GetComponent<IDamageReceiver>();
                damageReceiver.SubscribeToOnDeath(() => state = UnitState.Moving);

                state = UnitState.Action;
                StartCoroutine(attack.StartAttacking(damageReceiver));
            }
        }

        private void SetRange()
        {
            var bc = GetComponent<BoxCollider>();
            bc.center += new Vector3(combatStats.Range, 0, 0);
        }
    }
}
