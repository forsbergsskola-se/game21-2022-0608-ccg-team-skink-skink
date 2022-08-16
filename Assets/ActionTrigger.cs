using UnityEngine;

public class ActionTrigger : MonoBehaviour
{
  [SerializeField] private Animator Anim;
  
  public void Action() => Anim.SetTrigger("Action");
  
  public void Walk() => Anim.SetBool("IsWalking", true);
  
  public void Stop() => Anim.SetBool("IsWalking", false);

  public void Death() => Anim.SetTrigger("Death");
  
}
