using UnityEngine;

namespace Gameplay.Unit
{
    [CreateAssetMenu(fileName = "NewCombatStats", menuName = "ScriptableObjects/Unit/CombatStats")]
    public class CombatStats : ScriptableObject
    {
        [SerializeField] private float attackSpeed;
        [SerializeField] private int damage;
        [SerializeField] private int defence;

        public float AttackSpeed => attackSpeed;
        public int Damage => damage;
        public int Defence => defence;
    }
}
