using Meta.Interfaces;
using UnityEngine;

namespace Utility
{
    public class Dependencies : MonoBehaviour
    {
        [SerializeField, RequireInterface(typeof(ICardHand))] private Object testHand; // Todo: just for debugging

        public ICardHand PlayerCardHand => testHand as ICardHand;

        public Dependencies Instance { get; private set; }
        
        void Start()
        {
            Instance = this;
            DontDestroyOnLoad(this);
        }
    }
}
