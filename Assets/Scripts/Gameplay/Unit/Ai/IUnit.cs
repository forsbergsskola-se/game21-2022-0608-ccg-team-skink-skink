using UnityEngine;

namespace Gameplay.Unit.UnityAI
{
    public interface IUnit
    {
        public string Target { get; set; }
        public Vector3 Direction { get; set; }
    }
}
