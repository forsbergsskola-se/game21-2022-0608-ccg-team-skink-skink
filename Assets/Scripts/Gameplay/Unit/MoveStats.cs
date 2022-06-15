using UnityEngine;

namespace Gameplay.Unit
{
    [CreateAssetMenu(fileName = "NewMoveStats", menuName = "Unit/MoveStats")]
    public class MoveStats : ScriptableObject
    {
        [SerializeField] private float speed;
        [SerializeField] private float range;
        
        public float Speed => speed;
        public float Range => range;
    }
}
