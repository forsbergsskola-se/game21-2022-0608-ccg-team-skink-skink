using System.Collections;
using Gameplay.Unit.Health;
using Gameplay.Unit.StatsInterfaces;
using UnityEngine;

namespace Gameplay.Unit.UnitActions
{
    public class Attack
    {
        private ICombatStats stats;

        public Attack(ICombatStats stats) => this.stats = stats;

        public IEnumerator Execution(IDamageReceiver opponent)
        {
            opponent.TakeDamage(stats.Damage);
            yield return new WaitForSeconds(stats.AttackSpeed);
        }
        
        
        //TODO: Used for debug, changed to get the stats from character 
        public float Hit() => 50f;
    }
    
}
