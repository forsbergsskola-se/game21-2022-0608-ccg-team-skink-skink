using Meta.Interfaces;
using UnityEngine;

namespace Gameplay.AI
{
    [CreateAssetMenu(menuName = "ScriptableObjects/Utilities/Wave", fileName = "NewWaveSo")]
    public class WaveSO : ScriptableObject
    {
        [SerializeField] private int[] units = new int[6];
    }
}
