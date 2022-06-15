using UnityEngine;

namespace Gameplay.Unit
{
    [CreateAssetMenu(fileName = "NewHealthStats", menuName = "Unit/HealthStats")]
    public class HealthStats : ScriptableObject
    {
        [SerializeField] private int health;

        public int Health => health;
    }
}
