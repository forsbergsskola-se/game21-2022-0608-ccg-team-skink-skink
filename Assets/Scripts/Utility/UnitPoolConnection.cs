using System;
using System.Collections;
using System.Collections.Generic;
using Gameplay.Unit.Health;
using UnityEngine;
using Utility;

public class UnitPoolConnection : MonoBehaviour
{
    public Pool pool;
    public event Action<string, GameObject> ReturnToPool;
    public string key { get; set; }
    
    public void DeathEvent()
    {
        ReturnToPool?.Invoke(key, gameObject);
    }
}
