using Gameplay.Unit.StatsInterfaces;
using UnityEngine;

namespace Gameplay.AI.Unit.UnitActions
{
    public class Movement
    {
        private IMoveStats moveStats;
        
        public Movement(IMoveStats moveStats) => this.moveStats = moveStats;
       
        public void Move(Transform transform, Vector3 direction) 
            => transform.position += moveStats.Speed * direction;
    }
}
