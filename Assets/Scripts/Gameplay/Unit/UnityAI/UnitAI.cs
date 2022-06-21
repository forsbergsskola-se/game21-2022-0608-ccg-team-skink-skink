using System;
using Gameplay.Unit.UnitActions;
using Gameplay.Unit.Health;
using UnityEngine;

namespace Gameplay.Unit
{
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
            attack = new Attack(combatStats, state);

            state = UnitState.Moving;
        }
        
        private void FixedUpdate()
        {
            if(state == UnitState.Moving) movement.Move(transform, Direction);
        }

        private void OnTriggerEnter(Collider other)
        {
            state = UnitState.Action;
            var damageReceiver = other.GetComponent<IDamageReceiver>();

            if (damageReceiver != null && !other.gameObject.CompareTag(gameObject.tag))
            {
                Debug.Log("I am starting the attack");
                StartCoroutine(attack.StartAttacking(other.GetComponent<IDamageReceiver>()));
            }
        }
    }
}
