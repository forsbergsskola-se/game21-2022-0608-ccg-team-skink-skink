using System;
using Gameplay.Unit.UnitAI;
using UnityEngine;

namespace Gameplay.Unit.Animation
{
    public class AnimationController : MonoBehaviour
    {
        [SerializeField] private Animator animator;
        
        public void ChangeAnimation(UnitState state)
        {
            switch (state)
            {
                case UnitState.Moving:
                    animator.SetBool("IsWalking", true);
                    break;
                
                case UnitState.Action:
                    animator.SetBool("IsWalking", false);
                    animator.SetTrigger("Action");
                    break;
                
                case UnitState.Death:
                    animator.SetBool("IsWalking", false);
                    animator.SetTrigger("Death");
                    break;
                
                default:
                    throw new Exception("State not valid");
            }
        }
    }
}
