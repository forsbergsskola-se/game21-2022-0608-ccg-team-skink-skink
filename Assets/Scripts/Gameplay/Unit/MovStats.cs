using UnityEngine;

namespace Gameplay.Unit
{
    [CreateAssetMenu(fileName = "NewMovStats", menuName = "Unit/MovStats")]
    public class MovStats : ScriptableObject
    {
        [SerializeField] private float speed;
        [SerializeField] private float range;
        
        public float Speed => speed;
        public float Range => range;
    }
}
