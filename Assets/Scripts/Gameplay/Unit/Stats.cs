using UnityEngine;

namespace Gameplay.Unit
{
    [CreateAssetMenu(fileName = "NewUnitStats", menuName = "Unit/Stats")]
    public class Stats : ScriptableObject
    {
        [SerializeField] private float speed;
        [SerializeField] private float range;
        [SerializeField] private int cost;
        [SerializeField] private float baseHealth;
        [SerializeField] private float damage;
        [SerializeField] private float attackSpeed;

        public float Speed => speed;
        public float Range => range;

        public int Cost => cost;
        public float BaseHealth => baseHealth;
        public float Damage => damage;
        public float AttackSpeed => attackSpeed;
    }
}
