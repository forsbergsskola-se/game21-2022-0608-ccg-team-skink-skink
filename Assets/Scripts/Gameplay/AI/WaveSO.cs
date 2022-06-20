using Meta.Interfaces;
using UnityEngine;

namespace Gameplay.AI
{
    [CreateAssetMenu(menuName = "ScriptableObjects/Utilities/Wave", fileName = "NewWaveSO")]
    public class WaveSO : ScriptableObject
    {
        [SerializeField] private int[] units = new int[6];

        public int[] Units => units;
    }
}
