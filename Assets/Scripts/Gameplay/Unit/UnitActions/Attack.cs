using System.Collections;
using Gameplay.Unit.Health;
using Gameplay.Unit.StatsInterfaces;
using UnityEngine;

namespace Gameplay.Unit.UnitActions
{
    public class Attack
    {
        private ICombatStats stats;
        private UnitState state;

        private bool targetIsAlive = true;

        public Attack(ICombatStats stats, UnitState state)
        {
            this.stats = stats;
            this.state = state;
        } 

        public IEnumerator StartAttacking(IDamageReceiver opponent)
        {
            //Todo: Discuss with the designers how to manage attack coolDown
            float coolDown = 2f;
            opponent.SubscribeToOnDeath(StopAttacking);

            while (targetIsAlive)
            {
                opponent.TakeDamage(stats.Damage);
                Debug.Log("I am attacking!");
                yield return new WaitForSeconds(coolDown / stats.AttackSpeed);
            }

            yield return null;
        }

        public void StopAttacking()
        {
            state = UnitState.Moving;
            targetIsAlive = false;
        }
    }
    
}
