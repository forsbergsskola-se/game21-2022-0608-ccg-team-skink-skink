using System;
using Gameplay.AI.Unit.Behaviours;
using Gameplay.Unit;
using UnityEngine;

namespace Gameplay.AI.Unit
{
    public class UnitAITrigger : MonoBehaviour
    {
        [Header("Dependencies")]
        [SerializeField] private Stats stats;
        
        private Movement movement;
        private Attack attack;
        
        public string Target { get; set; }
        public Vector3 Direction { get; set; }

        private void Awake()
        {
            movement = new Movement(stats.Speed);
            attack = new Attack();
        }

        private void Start() 
            => StartCoroutine(movement.Move(GetComponentInParent<Transform>(), Direction));

        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag(Target))
            {
                StopAllCoroutines();
                StartCoroutine(attack.Hit());
            }
        }
    }
}
