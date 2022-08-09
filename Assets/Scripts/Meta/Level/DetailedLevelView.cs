using Meta.Interfaces;
using TMPro;
using UnityEngine;

namespace Meta.Level
{
    public class DetailedLevelView : MonoBehaviour, IDetailedLevelViewer
    {
        [SerializeField] private TMP_Text levelDescriptionTextBox;

        public void ActivateDetailedLevelViewer(IGameplayLevel gameplayLevel)
        {
            
        }
    }
}
