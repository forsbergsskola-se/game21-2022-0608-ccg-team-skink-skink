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
                tempObj.SetActive(false);
                pool.Enqueue(tempObj);
            }
            
            collection.Add(key, pool);
        }

        public GameObject GetInstance(string key)
        {
            var temp = collection[key].Dequeue();
            temp.SetActive(true);
            collection[key].Enqueue(temp);

            return temp;
        }
        
    }
    
}
