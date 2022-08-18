using System;
using Meta.Interfaces;
using UnityEngine;
using UnityEngine.UI;
using Utility;

namespace Meta.Level
{
    public class BasicLevelView : MonoBehaviour, IBasicLevelViewer
    {
        [SerializeField] private Button button;
        [SerializeField] private int number;

        public ILevel Level { get; set; }

        public event Action<int> OnClick;

        public bool Unlocked
        {
            get => button.interactable;
            set => button.interactable = value;
        }

        public void TriggerOnClick() {
            OnClick?.Invoke(number);
        }

        public void OnEnable() {
            var levelsModel = Dependencies.Instance.LevelsModel;
            DetermineIfUnlocked(levelsModel.CurrentMaxLevelIndex);
            levelsModel.MaxLevelIndexChanged += DetermineIfUnlocked;
        }

        private void DetermineIfUnlocked(int currentLevelNumber) {
            Unlocked = number <= currentLevelNumber;
        }
    }
}
