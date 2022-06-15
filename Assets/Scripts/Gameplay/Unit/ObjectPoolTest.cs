using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;

public class ObjectPoolTest : MonoBehaviour
{
    private IObjectPool<OPUnit> _pool;

    private void Update()
    {
        var unit = _pool.Get();
    }

    // private void Awake() => _pool = new IObjectPool<OPUnit>(CreateUnit(), OnTakeUnitFromPool, OnReturnUnitToPool);

    // OPUnit CreateUnit()
    // {
    //     var unit = Instantiate(unit, transform.position, Quaternion.identity);
    //     unit.SetPool(_pool);
    //     return unit;
    // }

    void OnTakeUnitFromPool(OPUnit unit)
    {
        unit.gameObject.SetActive(true);
    }

    // void OnReturnUnitToPool(OPUnit unit)
    // {
    //     if (unitPool != null && unitPool.isActiveAndEnabled)
    //         unitPool.Pool.Get().transform.position = unit.transform.position;
    //     unit.gameObject.SetActive(false);
    // }
}
