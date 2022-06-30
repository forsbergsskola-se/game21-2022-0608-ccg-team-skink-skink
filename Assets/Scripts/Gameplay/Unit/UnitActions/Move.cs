using Gameplay.Unit.StatsInterfaces;
using UnityEngine;

namespace Gameplay.Unit.UnitActions
{
    public class Movement
    {
        private IMoveStats stats;
        
        public Movement(IMoveStats stats) => this.stats = stats;
       
        public void Move(Transform transform, Vector3 direction) 
            => transform.position += stats.Speed * direction;
    }
}
