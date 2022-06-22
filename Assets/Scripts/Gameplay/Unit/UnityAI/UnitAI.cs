using System;
using Gameplay.Unit.Health;
using Gameplay.Unit.UnitActions;
using Unity.VisualScripting;
using UnityEngine;

namespace Gameplay.Unit.UnityAI
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
            attack = new Attack(combatStats);

            state = UnitState.Moving;
        }
        
        private void FixedUpdate()
        {
            if(state == UnitState.Moving) movement.Move(transform, Direction);
        }

        private void OnTriggerEnter(Collider other)
        {
            var damageReceiver = other.GetComponent<IDamageReceiver>();
            damageReceiver.SubscribeToOnDeath(() => state = UnitState.Moving);

            if (damageReceiver != null && !other.gameObject.CompareTag(gameObject.tag))
            {
                state = UnitState.Action;
                Debug.Log("I am starting the attack");
                StartCoroutine(attack.StartAttacking(damageReceiver));
            }
        }
    }
}
