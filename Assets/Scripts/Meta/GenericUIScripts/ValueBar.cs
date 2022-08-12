using Meta.Interfaces;
using UnityEngine;
using UnityEngine.UI;

namespace Meta.GenericUIScripts {
    public class ValueBar : MonoBehaviour, IUIValueBar {
        [SerializeField] Slider slider;
        [SerializeField] float maxValue;
    
        public void Awake() {
            slider.maxValue = maxValue;
        }
        public void SetValue(float value) {
            slider.value = value;
        }
    }
}
