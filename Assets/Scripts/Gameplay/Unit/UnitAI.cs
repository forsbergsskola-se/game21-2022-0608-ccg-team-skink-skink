using System.Collections;
using System.Collections.Generic;
using Gameplay.Unit.UnitActions;
using Gameplay.Unit;
using Gameplay.Unit.Health;
using UnityEngine;

namespace Gameplay.Unit
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
        //TODO:Maybe create own class/interface for this
        float cooldown;
        [SerializeField] float timeBetweenAttacks = 4f;

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
                        state = UnitState.Action;
                    }
                    break;
                
                case UnitState.Action:
                    //TODO: If is player look for enemy, if is enemy look for player tag
                    if (Physics.Raycast(transform.position,Direction, out RaycastHit hitTarget))
                    {
                        IDamageReceiver damageReceiver = hitTarget.collider.GetComponent<IDamageReceiver>();
                        if (damageReceiver != null)
                        {
                            cooldown += Time.deltaTime;
                            if (cooldown > timeBetweenAttacks)
                            {
                                damageReceiver.TakeDamage(attack.Hit());
                                Debug.Log("Should be dealing damage");
                                cooldown -= timeBetweenAttacks;
                            }
                            
                        }
                    }
                    break;
            }
        }
    }
}
