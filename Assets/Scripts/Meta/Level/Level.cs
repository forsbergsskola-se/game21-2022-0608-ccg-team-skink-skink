using Meta.Interfaces;
using UnityEngine;

namespace Meta.Level
{
    public class Level : MonoBehaviour, ILevel
    {
        [SerializeField] private string visualName;
        [SerializeField] private int index;
        [SerializeField] private string internalSceneName;

        public string Name => visualName;
        public int Index => index;
        public string InternalSceneName => internalSceneName;
    }
}
