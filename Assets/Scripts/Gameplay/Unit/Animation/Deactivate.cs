using UnityEngine;

namespace Gameplay.Unit.Animation
{
    public class Deactivate : MonoBehaviour
    {
        public void Parent() => transform.parent.gameObject.SetActive(false);

        public void Self() => transform.gameObject.SetActive(false);
    }
}
