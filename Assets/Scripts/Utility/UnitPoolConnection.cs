using System;
using System.Collections;
using System.Collections.Generic;
using Gameplay.Unit.Health;
using UnityEngine;
using Utility;

namespace Utility
{
public class UnitPoolConnection : MonoBehaviour
{
    public event Action<string, GameObject> ReturnToPool;
    public string key { get; set; }
    
    public void DeathEvent()
    {
        ReturnToPool?.Invoke(key, gameObject);
        gameObject.SetActive(false);
    }
}
}
