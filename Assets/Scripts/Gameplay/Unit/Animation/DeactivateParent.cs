using UnityEngine;

namespace Gameplay.Unit.Animation
{
    public class DeactivateParent : MonoBehaviour
    {
        public void Deactivate() => transform.parent.gameObject.SetActive(false);
    }
}
