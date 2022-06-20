using Gameplay.Unit.StatsInterfaces;
using UnityEngine;

namespace Gameplay.Unit
{
    [CreateAssetMenu(fileName = "NewMoveStats", menuName = "ScriptableObjects/Unit/MoveStats")]
    public class MoveStats : ScriptableObject, IMoveStats
    {
        [SerializeField] private float speed;
        [SerializeField] private float range;
        
        public float Speed => speed;
        public float Range => range;
    }
}
