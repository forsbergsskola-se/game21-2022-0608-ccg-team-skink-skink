using System;
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
                    animator.SetTrigger("Action");
                    animator.SetBool("IsWalking", false);
                    break;
                
                default:
                    throw new Exception("State not valid");
            }
        }
    }
}
