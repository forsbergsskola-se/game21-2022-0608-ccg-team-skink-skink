using System.Collections.Generic;
using UnityEngine;

namespace Utility
{
    [CreateAssetMenu(menuName = "ScriptableObjects/Utilities/Pool",fileName = "NewPool")]
    public class Pool : ScriptableObject
    {
        private Dictionary<string, Queue<GameObject>> collection = new();

        public void CreatePool(string key, GameObject card, int cardAmount)
        {
            var pool = new Queue<GameObject>();
            
            for (int i = 0; i < cardAmount; i++)
            {
                var tempObj = Instantiate(card);
                
                // var unitConnect = tempObj.GetComponent<UnitPoolConnection>();
                // unitConnect.ReturnToPool += ReturnToPool;
                // unitConnect.key = key;
                
                tempObj.SetActive(false);
                pool.Enqueue(tempObj);
            }
            collection.Add(key, pool);
        }

        public GameObject GetInstance(string key)
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

            //TODO: Add "Garbage Collection" to the Pool if necessary
            
            return dequeued;
        }

        public void ReturnToPool(string key, GameObject unit)
        {
            collection[key].Enqueue(unit);
            Debug.Log("Added object: " + unit);
            Debug.Log("Objects in queue: " + collection[key].Count);
        }
        
    }
    
}
