using System.Collections;
using Gameplay.Unit.StatsInterfaces;
using UnityEngine;

namespace Gameplay.AI.Unit.Behaviours
{
    public class Movement
    {
        private IMoveStats moveStats;
        
        public Movement(IMoveStats moveStats) => this.moveStats = moveStats;
       
        public IEnumerator Move(Transform transform, Vector3 direction)
        {
            yield return transform.position += moveStats.Speed * direction;
        }
    }
}
