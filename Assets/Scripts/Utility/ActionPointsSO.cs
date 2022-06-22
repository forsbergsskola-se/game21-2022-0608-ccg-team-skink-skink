using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Utility
{
    [CreateAssetMenu(menuName = "ScriptableObjects/Utilities/ActionPointsHolder", fileName = "NewActionPointSO")]
    public class ActionPointsSO : ScriptableObject
    {
        [SerializeField] private uint startAP;
        [SerializeField] private uint maxAP;
        [SerializeField] private float regenAP;
       // [SerializeField] private float regenSpeed;

        public uint StartAP => startAP;
        public uint MaxAP => maxAP;
        public float APRegen => regenAP;
       // public float RegenSpeed => regenSpeed;
    }
}

