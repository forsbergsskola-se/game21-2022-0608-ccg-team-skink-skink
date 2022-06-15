using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;

public class OPUnit : MonoBehaviour
{
    private IObjectPool<OPUnit> _pool;
    public void SetPool(IObjectPool<OPUnit> pool) => _pool = pool;
    
    
}
