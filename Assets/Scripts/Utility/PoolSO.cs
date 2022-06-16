using System.Collections.Generic;
using UnityEngine;

namespace Utility
{
    [CreateAssetMenu(menuName = "Utilities/Pool",fileName = "NewPool")]

    public class PoolSO : ScriptableObject
    {
    
        public Queue<GameObject> pool;

   

    }
}
