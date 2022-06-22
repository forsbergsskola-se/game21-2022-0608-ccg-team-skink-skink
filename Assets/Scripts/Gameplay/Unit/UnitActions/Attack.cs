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
            
            //Todo: Discuss with the designers how to manage attack coolDown
            float coolDown = 2f;
            opponent.SubscribeToOnDeath(StopAttacking);

            while (targetIsAlive)
            {
                opponent.TakeDamage(stats.Damage);
                yield return new WaitForSeconds(coolDown / stats.AttackSpeed);
            }

            yield return null;
        }

        private void StopAttacking() => targetIsAlive = false;
    }
    
}
