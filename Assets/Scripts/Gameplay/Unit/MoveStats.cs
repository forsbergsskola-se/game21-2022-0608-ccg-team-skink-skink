using Gameplay.Unit.StatsInterfaces;
using UnityEngine;

namespace Gameplay.Unit
{
    [CreateAssetMenu(fileName = "NewMoveStats", menuName = "ScriptableObjects/Unit/MoveStats")]
    public class MoveStats : ScriptableObject, IMoveStats
    {
        [SerializeField] private float speed;
        
        public float Speed => speed;
    }
}
