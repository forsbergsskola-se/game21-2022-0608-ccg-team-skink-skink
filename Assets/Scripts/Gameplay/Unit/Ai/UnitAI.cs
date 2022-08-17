using System;
using System.Collections.Generic;
using Gameplay.Unit.Health;
using Gameplay.Unit.UnitActions;
using Gameplay.Unit.UnitAI;
using Gameplay.Unit.UnityAI;
using UnityEngine;
using UnityEngine.Events;

namespace Gameplay.Unit.Ai
{
    [RequireComponent(typeof(BoxCollider))]
    [RequireComponent(typeof(HealthComponent))]
    public class UnitAI : MonoBehaviour, IUnit
    {
        [Header("Dependencies")]
        [SerializeField] private MoveStats moveStats;
        [SerializeField] private CombatStatsSO combatStatsSO;
        [SerializeField] private UnityEvent<UnitState> onStateChanges;
        
        public MoveStats MoveStats => moveStats;
        public CombatStatsSO CombatStats => combatStatsSO;

        private Movement movement;
        private Attack attack;
        private IDamageReceiver health;
        private List<Collider> triggerCollection = new();

        private UnitState state;
        
        private UnitState State
        {
            get => state;
            set
            {
                state = value;
                onStateChanges.Invoke(state);
            }
        }
        
        public string Target { get; set; }
        public Vector3 Direction { get; set; }
        
        private void Awake()
        {
            movement = new Movement(moveStats);
            attack = new Attack(combatStatsSO, () => onStateChanges.Invoke(state));
            
            State = UnitState.Moving;
        }

        private void FixedUpdate()
        {
            if (State == UnitState.Moving) movement.Move(transform, Direction);
        }

        private void OnTriggerStay(Collider other)
        {
            if (!other.gameObject.CompareTag(tag) && !triggerCollection.Contains(other))
            {
                if (Vector3.Distance(transform.position, other.transform.position) <= combatStatsSO.Range)
                    triggerCollection.Add(other);
            }
            
            if (State != UnitState.Action && triggerCollection.Count != 0) StartAttacking(triggerCollection[0]);
        }

        private void OnTriggerExit(Collider other)
        {
            if (triggerCollection.Contains(other)) triggerCollection.Remove(other);
        }

        private void StartAttacking(Collider other)
        {
            State = UnitState.Action;
            var otherHealth = other.GetComponent<IDamageReceiver>();

            otherHealth.SubscribeToOnDeath((UnitState state) =>
                {
                    State = UnitState.Moving;
                    triggerCollection.Remove(other);
                }
            );
            StartCoroutine(attack.StartAttacking(otherHealth));
        }
    }
}

