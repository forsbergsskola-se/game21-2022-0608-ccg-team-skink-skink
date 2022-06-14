using UnityEngine;

namespace Gameplay.Unit
{
    [CreateAssetMenu(fileName = "NewUnitStats", menuName = "Unit/Stats")]
    public class Stats : ScriptableObject
    {
        [SerializeField] private float speed;
        [SerializeField] private Vector3 direction;
        [SerializeField] private float range;
        [SerializeField] private int cost;
        [SerializeField] private float health;
        [SerializeField] private float damage;
        [SerializeField] private float attackSpeed;

        public float Speed => speed;
        public Vector3 Direction => direction;
        public float Range => range;

        public int Cost => cost;
        public float Health => health;
        public float Damage => damage;
        public float AttackSpeed => attackSpeed;
    }
}
