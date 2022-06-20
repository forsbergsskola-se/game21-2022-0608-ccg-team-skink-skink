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
                
                var unitConnect = tempObj.GetComponent<UnitPoolConnection>();
                unitConnect.ReturnToPool += ReturnToPool;
                unitConnect.key = key;
                
                tempObj.SetActive(false);
                pool.Enqueue(tempObj);
            }
            collection.Add(key, pool);
        }

        public GameObject GetInstance(string key)
        {
            var temp = collection[key].Dequeue();
            temp.SetActive(true);
            
            //TODO: Fix and replace so that this doesn't grab alive units 
            //collection[key].Enqueue(temp);

            return temp;
        }

        public void ReturnToPool(string key, GameObject unit)
        {
            collection[key].Enqueue(unit);
            Debug.Log("Added object: " + unit);
            Debug.Log("Objects in queue: " + collection[key].Count);
        }
        
    }
    
}
