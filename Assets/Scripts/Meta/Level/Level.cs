using Meta.Interfaces;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Meta.Level
{
    public class Level : MonoBehaviour, ILevel
    {
        [SerializeField] private string visualName;
        [SerializeField] private int index;
        [SerializeField] private string internalSceneName;

        private void Awake()
        {
            Name = visualName;
            Index = index;
            InternalSceneName = internalSceneName;
        }


        public string Name { get; private set; }
        public int Index { get; private set; }
        public string InternalSceneName { get; private set; }
    }
}
