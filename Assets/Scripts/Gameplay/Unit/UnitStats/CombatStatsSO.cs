using Gameplay.Unit.StatsInterfaces;
using UnityEngine;

namespace Gameplay.Unit
{
    [CreateAssetMenu(fileName = "NewCombatStats", menuName = "ScriptableObjects/Unit/CombatStats")]
    public class CombatStatsSO : ScriptableObject, ICombatStats
    {
        [SerializeField] private float attackSpeed;
        [SerializeField] private float damage;
        [SerializeField] private int defence;
        [SerializeField] private float range;
        
        public float AttackSpeed => attackSpeed;
        public float Range => range;
        public float Damage => damage;
        public int Defence => defence;
    }
}
