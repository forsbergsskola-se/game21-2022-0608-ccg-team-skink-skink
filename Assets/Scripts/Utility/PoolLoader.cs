using System.Collections.Generic;
using UnityEngine;

namespace Utility
{
    public class PoolLoader : MonoBehaviour
    {
        [SerializeField] private PoolSO pool;

        public List<GameObject> prefabs;

        private void Awake()
        {
            foreach (var prefab in prefabs )
            {
                var temp = Instantiate(prefab);
                pool.pool.Enqueue(temp);
            }
        }
    }
}
