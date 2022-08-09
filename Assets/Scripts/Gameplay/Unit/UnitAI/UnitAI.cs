using System.Collections.Generic;
using Gameplay.Unit.Health;
using Gameplay.Unit.UnitActions;
using Gameplay.Unit.UnityAI;
using UnityEngine;
using UnityEngine.Events;

namespace Gameplay.Unit.UnitAI
{
    [RequireComponent(typeof(BoxCollider))]
    public class UnitAI : MonoBehaviour, IUnit
    {
        [Header("Dependencies")]
        [SerializeField] private MoveStats moveStats;

        [SerializeField] private CombatStatsSO combatStatsSO;

        [SerializeField] private UnityEvent<UnitState> onStateChanges;

        private Movement movement;
        private Attack attack;
        private List<Collider> triggerCollection = new();
        
        private UnitState State
        {
            get => this.State;
            set
            {
                State = value;
                onStateChanges.Invoke(State);
            } }
        
        public string Target { get; set; }
        public Vector3 Direction { get; set; }
        
        private void Awake()
        {
            LoadComponents();
            SetInitialState();
            SetRange();
        }

        private void FixedUpdate()
        {
            if(State == UnitState.Moving) movement.Move(transform, Direction);
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.CompareTag(tag)) return;
            
            if (!triggerCollection.Contains(other)) triggerCollection.Add(other);
                
            if (State != UnitState.Action) StartAttacking(other);
        }

        private void OnTriggerStay(Collider other)
        {
            if (triggerCollection.Count == 0 || State == UnitState.Action) return;
            
            StartAttacking(triggerCollection[0]);
        }

        private void OnTriggerExit(Collider other)
        {
            if (triggerCollection.Contains(other)) triggerCollection.Remove(other);
        }

        private void SetInitialState() => State = UnitState.Moving;
        
        private void SetRange() 
            => GetComponent<BoxCollider>().center += new Vector3(combatStatsSO.Range, 0, 0);
        
        private void LoadComponents()
        {
            movement = new Movement(moveStats);
            attack = new Attack(combatStatsSO);
        }

        private void StartAttacking(Collider other)
        {
            var damageReceiver = other.GetComponent<IDamageReceiver>();

            damageReceiver.SubscribeToOnDeath(() =>
            {
                State = UnitState.Moving;
                triggerCollection.Remove(other);
            });
            
            State = UnitState.Action;
            StartCoroutine(attack.StartAttacking(damageReceiver));
        }
    }
}

