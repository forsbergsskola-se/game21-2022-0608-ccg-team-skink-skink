using UnityEngine;

namespace Utility
{
    [CreateAssetMenu(menuName = "ScriptableObjects/Utilities/ActionPointsHolder", fileName = "NewActionPointSO")]
    public class ActionPointsSO : ScriptableObject
    {
        [SerializeField] private uint start;
        [SerializeField] private uint max;
        [SerializeField] private float regen;
       
        public uint Start => start;
        public uint Max => max;
        public float Regen => regen;
       
    }
}

