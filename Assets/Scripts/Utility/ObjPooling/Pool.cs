using System.Collections.Generic;
using UnityEngine;

namespace Utility
{
    [CreateAssetMenu(menuName = "ScriptableObjects/Utilities/Pool",fileName = "NewPool")]
    public class Pool : ScriptableObject
    {
        private Dictionary<sbyte, Queue<GameObject>> collection = new();

        public void CreatePool(sbyte key, GameObject card, int cardAmount)
        {
            var pool = new Queue<GameObject>();
            
            for (int i = 0; i < cardAmount; i++)
            {
                var tempObj = Instantiate(card);
                
                tempObj.SetActive(false);
                pool.Enqueue(tempObj);
            }
            collection.Add(key, pool);
        }

        public GameObject GetInstance(sbyte key)
        {
            var dequeued = collection[key].Dequeue();
            if (dequeued.gameObject.activeInHierarchy)
            {
                var temp = Instantiate(dequeued);
                collection[key].Enqueue(dequeued);
                dequeued = temp;
            }
            dequeued.SetActive(true);
            collection[key].Enqueue(dequeued);

            return dequeued;
        }

    }
    
}
