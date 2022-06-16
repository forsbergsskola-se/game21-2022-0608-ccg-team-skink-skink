using System.Collections.Generic;
using UnityEngine;

namespace Utility
{
    [CreateAssetMenu(menuName = "Utilities/Pool",fileName = "NewPool")]
    public class PoolSO : ScriptableObject
    {
        public Dictionary<string, Queue<GameObject>> CardHandCollection;
        //public Queue<GameObject> pool = new ();
    }
}
