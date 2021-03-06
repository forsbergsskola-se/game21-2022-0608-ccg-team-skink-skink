using System.Collections;
using Gameplay.Unit.Health;
using Gameplay.Unit.StatsInterfaces;
using UnityEngine;

namespace Gameplay.Unit.UnitActions
{
    public class Attack
    {
        private ICombatStats stats;
        private bool targetIsAlive;

        public Attack(ICombatStats stats) => this.stats = stats;
        
        public IEnumerator StartAttacking(IDamageReceiver opponent)
        {
            targetIsAlive = true;
            
            opponent.SubscribeToOnDeath(StopAttacking);

            while (targetIsAlive)
            {
                opponent.TakeDamage(stats.Damage);
                yield return new WaitForSeconds(stats.AttackSpeed);
            }

            yield return null;
        }

        private void StopAttacking() => targetIsAlive = false;
    }
    
}
