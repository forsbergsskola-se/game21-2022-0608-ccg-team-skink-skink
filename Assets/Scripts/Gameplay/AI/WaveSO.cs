using UnityEngine;

namespace Gameplay.AI
{
    [CreateAssetMenu(menuName = "ScriptableObjects/Utilities/Wave", fileName = "NewWaveSo")]
    public class WaveSO : ScriptableObject
    {
        [SerializeField] private string[] units = new string[1];
    }
}
