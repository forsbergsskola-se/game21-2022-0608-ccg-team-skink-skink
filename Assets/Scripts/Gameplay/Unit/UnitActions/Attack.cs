using System;
using System.Collections;
using Gameplay.Unit.Health;
using Gameplay.Unit.StatsInterfaces;
using Gameplay.Unit.UnitAI;
using UnityEngine;

namespace Gameplay.Unit.UnitActions
{
    public class Attack
    {
        private ICombatStats stats;
        private bool targetIsAlive;
        private Action onAttack;

        public Attack(ICombatStats stats, Action subscribeOnAttack)
        {
            this.stats = stats;
            onAttack += subscribeOnAttack;
        }
        
        public IEnumerator StartAttacking(IDamageReceiver opponent)
        {
            targetIsAlive = true;
            
            opponent.SubscribeToOnDeath((UnitState state) => targetIsAlive = false);

            while (targetIsAlive)
            {
                onAttack.Invoke();
                opponent.TakeDamage(stats.Damage);
                yield return new WaitForSeconds(stats.AttackSpeed);
            }

            yield return null;
        }
    }
}
