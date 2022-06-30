using System;
using System.Collections;
using System.Collections.Generic;
using Gameplay.Unit.Health;
using UnityEngine;
using Utility;

namespace Utility
{
public class UnitDeathEvent : MonoBehaviour
{
    public void DeathEvent()
    {
        gameObject.SetActive(false);
    }
}
}
