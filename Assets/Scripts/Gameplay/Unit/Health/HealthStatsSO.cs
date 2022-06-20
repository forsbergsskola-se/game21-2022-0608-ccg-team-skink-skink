using UnityEngine;

namespace Gameplay.Unit
{
    [CreateAssetMenu(fileName = "NewHealthStats", menuName = "ScriptableObjects/Unit/HealthStats")]
    public class HealthStatsSO : ScriptableObject
    {
        [SerializeField] private float maxHealth;

        public float MaxHealth => maxHealth;
    }
}
