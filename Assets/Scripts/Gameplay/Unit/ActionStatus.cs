using UnityEngine;

namespace Gameplay.Unit
{
    [CreateAssetMenu(fileName = "NewAPStats", menuName = "Unit/APStats")]
    public class ActionStatus : ScriptableObject
    {
        [SerializeField] private int cost;
        [SerializeField] private float cooldownTimer;


        public int Cost => cost;
        public float CooldownTimer => cooldownTimer;
    }
}
