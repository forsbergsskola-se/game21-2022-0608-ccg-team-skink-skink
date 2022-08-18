using UnityEngine;
using UnityEngine.Events;

namespace Gameplay.Unit.Animation
{
    public class AttackTrigger : MonoBehaviour
    {
        [SerializeField] private UnityEvent onAttack;

        public void DealDamage() => onAttack.Invoke();
    }
}
