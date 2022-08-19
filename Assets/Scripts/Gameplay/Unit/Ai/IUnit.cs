using UnityEngine;

namespace Gameplay.Unit.Ai
{
    public interface IUnit
    {
        public string Target { get; set; }
        public Vector3 Direction { get; set; }
    }
}
