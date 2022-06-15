using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Config
public class CardSO : ScriptableObject 
{
    public string id;
    public int Health;
    public GameObject prefab;
    
    public interface IGameObjectPool
    {
        GameObject Get(string id);
        void Return(string id, GameObject gameObject);
    }
    Dictionary<string, List<GameObject>> pooledObjects;

    void GrabUnitFromPool()
    {
        // var skeleton = pool.Get("Skeleton"); 
        // Skeleton.OnDeath: pool.Return("Skeleton", this.gameObject); 
    }
    
}

// Meta
public class CardCollection
{
    public List<string> ownedCards;
}
