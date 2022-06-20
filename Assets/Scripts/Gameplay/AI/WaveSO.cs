using UnityEngine;

namespace Gameplay.AI
{
    [CreateAssetMenu(menuName = "ScriptableObjects/Utilities", fileName = "NewWaveSo")]
    public class WaveSo : ScriptableObject
    {
        [SerializeField] private string[] units = new string[1];
    }
}
