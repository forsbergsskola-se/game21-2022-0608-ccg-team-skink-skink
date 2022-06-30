using System;
using UnityEngine.Events;

namespace Gameplay.Unit.Health
{
    public interface IDamageReceiver
    {
       public void TakeDamage(float value);
       public void SubscribeToOnDeath(UnityAction method);

    } 
}
