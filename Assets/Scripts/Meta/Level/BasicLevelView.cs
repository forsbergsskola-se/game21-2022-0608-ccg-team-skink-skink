using System;
using Meta.Interfaces;
using UnityEngine;
using UnityEngine.UI;

namespace Meta.Level
{
    public class BasicLevelView : MonoBehaviour, IBasicLevelViewer
    {
        [SerializeField] private Button button;
        [SerializeField] private int number;

        public IGameplayLevel Level { get; set; }
        
        public event Action<int> OnClick;

        public bool Unlocked
        {
            get => button.interactable;
            set => button.interactable = value;
        }
    }
}
