using Gameplay.AI.Unit.UnitActions;
using Gameplay.Unit;
using Gameplay.Unit.Health;
using UnityEngine;

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
                        state = UnitState.Action;
                    }
                    break;
                
                case UnitState.Action:
                    //TODO:Clean up debug
                    Debug.Log("trying to attack");
                    //TODO:Remove magic numbers
                    if (Physics.Raycast(transform.position,Direction, out RaycastHit hitTarget))
                    {
                        Debug.Log("found target");
                        IDamageReceiver damageReceiver = hitTarget.collider.GetComponent<IDamageReceiver>();
                        if (damageReceiver != null)
                        {
                            Debug.Log("trying to deal damage");
                            damageReceiver.TakeDamage(attack.Hit());
                        }
                    }
                    break;
            }
        }
    }
}
