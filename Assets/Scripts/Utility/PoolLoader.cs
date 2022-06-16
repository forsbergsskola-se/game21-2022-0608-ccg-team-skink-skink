using System;
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
                pool.pool.Enqueue(prefab);
            }
        }
    }
}
