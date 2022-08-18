using Meta.Interfaces;
using TMPro;
using UnityEngine;

namespace Meta.Level
{
    public class DetailedLevelView : MonoBehaviour, IDetailedLevelViewer
    {
        [SerializeField] private TMP_Text levelDescriptionTextBox;
        [SerializeField] private TMP_Text levelNameTextBox;

        public void ActivateDetailedLevelViewer(ILevel gameplayLevel) {
            this.gameObject.SetActive(true);
            levelDescriptionTextBox.text = gameplayLevel.Description;
            levelNameTextBox.text = gameplayLevel.Name;
        }
        public void DeactivateDetailedLevelViewer() {
            this.gameObject.SetActive(false);
        }
    }
}
