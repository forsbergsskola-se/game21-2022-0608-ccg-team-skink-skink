using System;
using Gameplay.Unit.UnitAI;
using UnityEngine;

namespace Gameplay.Unit.Animation
{
    public class AnimationController : MonoBehaviour
    {
        [SerializeField] private Animator animator;
        [SerializeField] private CombatStatsSO combatStats;
        
        public void ChangeAnimation(UnitState state)
        {
            switch (state)
            {
                case UnitState.Moving:
                    animator.SetBool("IsWalking", true);
                    animator.speed = 1;
                    break;
                
                case UnitState.Action:
                    animator.SetBool("IsWalking", false);
                    animator.SetTrigger("Action");
                    animator.speed = combatStats.AttackSpeed;
                    break;
                
                case UnitState.Death:
                    animator.SetBool("IsWalking", false);
                    animator.SetTrigger("Death");
                    animator.speed = 1;
                    break;
                
                default:
                    throw new Exception("State not valid");
            }
        }
    }
}
