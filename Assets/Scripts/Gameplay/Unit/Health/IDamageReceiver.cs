using System;
using Gameplay.Unit.UnitAI;
using UnityEngine.Events;

namespace Gameplay.Unit.Health
{
    public interface IDamageReceiver
    { 
       public float CurrentHealth { get; }
       public void TakeDamage(float value);
       public void SubscribeToOnDeath(UnityAction<UnitState> method);

    } 
}
