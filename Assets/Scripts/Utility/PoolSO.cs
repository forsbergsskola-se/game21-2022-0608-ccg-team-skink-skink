using System.Collections.Generic;
using UnityEngine;

namespace Utility
{
    [CreateAssetMenu(menuName = "Utilities/Pool",fileName = "NewPool")]
    public class PoolSO : ScriptableObject
    {
        public Dictionary<string, Queue<GameObject>> CardHandCollection = new();
        //public Queue<GameObject> pool = new ();

        public void CreatePool(string name, GameObject card, int cardAmount)
        {
            var pool = new Queue<GameObject>();
            for (int i = 0; i < cardAmount; i++)
            {
                var tempObj = Instantiate(card);
                tempObj.SetActive(false);
                pool.Enqueue(tempObj);
            }
            CardHandCollection.Add(name, pool);
        }
    }
    
}
