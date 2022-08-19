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
        public IDamageReceiver Target { get; set; }
        
        private ICombatStats stats;
        private Action onAttack;

        public Attack(ICombatStats stats, Action subscribeOnAttack)
        {
            this.stats = stats;
            onAttack += subscribeOnAttack;
        }
        
        public void StartAttacking()
        {
            onAttack.Invoke();
            Target.TakeDamage(stats.Damage);
        }
    }
}
