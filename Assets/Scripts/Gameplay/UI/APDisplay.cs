using TMPro;
using UnityEngine;

namespace Gameplay.UI
{
   [RequireComponent(typeof(TextMeshProUGUI))]
   public class APDisplay : MonoBehaviour
   {
      private TextMeshProUGUI mesh;

      private void Awake() 
         => mesh = GetComponent<TextMeshProUGUI>();
      
      public void UpdateAPDisplay(uint currentAP, uint maxAP)
         => mesh.text = $"AP: {currentAP} / {maxAP}";
   }
}
