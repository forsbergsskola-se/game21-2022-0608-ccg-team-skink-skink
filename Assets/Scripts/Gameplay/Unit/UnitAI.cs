using System;
using Gameplay.Unit.UnitActions;
using Gameplay.Unit.Health;
using UnityEngine;

namespace Gameplay.Unit
{
    public class UnitAI : MonoBehaviour
    {
        [Header("Dependencies")]
        [SerializeField] private MoveStats moveStats;
        [SerializeField] private CombatStats combatStats;
        
        private Movement movement;
        private Attack attack;
        private UnitState state;
        
        public string Target { get; set; }
        public Vector3 Direction { get; set; }
        
        
        //TODO:Maybe create own class/interface for this
        float cooldown;
        [SerializeField] float timeBetweenAttacks = 4f;

        private void Awake()
        {
            movement = new Movement(moveStats);
            attack = new Attack(combatStats);

            state = UnitState.Moving;
        }
        
        private void FixedUpdate()
        {
            if(state == UnitState.Moving) movement.Move(transform, Direction);
            
            // switch (state)
            // {
            //     case UnitState.Moving:
            //         
            //         
            //         if (Physics.SphereCast(transform.position, 1, Direction, out RaycastHit hit, moveStats.Range) 
            //             && hit.transform.CompareTag(Target))
            //         {
            //             state = UnitState.Action;
            //         }
            //         break;
            //     
            //     case UnitState.Action:
            //         //TODO: If is player look for enemy, if is enemy look for player tag
            //         if (Physics.Raycast(transform.position,Direction, out RaycastHit hitTarget))
            //         {
            //             IDamageReceiver damageReceiver = hitTarget.collider.GetComponent<IDamageReceiver>();
            //             if (damageReceiver != null)
            //             {
            //                 cooldown += Time.deltaTime;
            //                 if (cooldown > timeBetweenAttacks)
            //                 {
            //                     damageReceiver.TakeDamage(attack.Hit());
            //                     Debug.Log("Should be dealing damage");
            //                     cooldown -= timeBetweenAttacks;
            //                 }
            //             }
            //         }
            //         break;
            // }
        }

        private void OnTriggerEnter(Collider other)
        {
            state = UnitState.Action;
            StartCoroutine(attack.execution());
        }
    }
}
