using Gameplay.Unit.Health;
using Gameplay.Unit.UnitActions;
using UnityEngine;

namespace Gameplay.Unit.UnityAI
{
    [RequireComponent(typeof(BoxCollider))]
    public class UnitAI : MonoBehaviour, IUnit
    {
        [Header("Dependencies")]
        [SerializeField] private MoveStats moveStats;
        [SerializeField] private CombatStatsSO combatStatsSO;
        
        private Movement movement;
        private Attack attack;
        private UnitState state;
        
        public string Target { get; set; }
        public Vector3 Direction { get; set; }
        
        private void Awake()
        {
            movement = new Movement(moveStats);
            attack = new Attack(combatStatsSO);

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
                //TODO: Make sure to cease action upon death event
                StartCoroutine(attack.StartAttacking(damageReceiver));
            }
        }

        private void SetRange()
        {
            var collider = GetComponent<BoxCollider>();
            collider.center += new Vector3(combatStatsSO.Range, 0, 0);
        }
    }
}

//Todo: Create a List of colliders
//Todo: Add other colliders on trigger enter
//Todo: Remove Colliders on trigger exit or OnDeathEvent
//Todo: Attack a new target on trigger stay
