using System;

namespace Gameplay.Unit.StatsInterfaces
{
    public interface ICombatStats
    {
        public float Damage { get; }
        public float AttackSpeed { get; }
        public float Range { get; }
        // public float Defence { get; set; }
        
    }
}
