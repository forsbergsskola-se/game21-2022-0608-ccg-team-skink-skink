using System.Collections;
using Gameplay.Unit.StatsInterfaces;

namespace Gameplay.Unit.UnitActions
{
    public class Attack
    {
        private ICombatStats stats;

        public Attack(ICombatStats stats) => this.stats = stats;

        public IEnumerator execution()
        {
            yield return null;
        }
        
        
        //TODO: Used for debug, changed to get the stats from character 
        public float Hit() => 50f;
    }
    
}
