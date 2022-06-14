using Gameplay.AI.Unit.Behaviours;
using Gameplay.Unit;
using UnityEngine;

namespace Gameplay.AI.Unit
{
    public class UnitAI : MonoBehaviour
    {
        [Header("Dependencies")]
        [SerializeField] private Stats stats;
        
        private Movement movement;
        private Attack attack;
        
        public string Target { get; set; }
        public Vector3 Direction { get; set; }

        private void Awake()
        {
            movement = new Movement(stats.Speed, Direction);
            attack = new Attack();
        }

        private void FixedUpdate()
        {
            if (Physics.SphereCast(transform.position, 1, Direction, out RaycastHit hit, stats.Range) 
                && hit.transform.CompareTag(Target))
            {
                StartCoroutine(attack.Hit());
            }
            else StartCoroutine(movement.Move(this.transform, Direction));
        }
    }
}
