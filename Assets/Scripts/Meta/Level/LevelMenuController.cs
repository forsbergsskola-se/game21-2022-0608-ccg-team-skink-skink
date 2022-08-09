using System;
using Meta.Interfaces;
using UnityEngine;
using Utility;
using Object = UnityEngine.Object;

namespace Meta.Level
{
    public class LevelMenuController : MonoBehaviour
    {
        [SerializeField, RequireInterface(typeof(GameplayLevelSO))] private Object[] levelsInOrder;

        [SerializeField, RequireInterface(typeof(IDetailedLevelViewer))] private Object detailedLevelViewer;

        private GameplayLevelSO[] levels;

        private void Awake()
        {
            levels = Array.ConvertAll(levelsInOrder, input => input as GameplayLevelSO);

            var basicLevelViewers = GetComponentsInChildren<IBasicLevelViewer>();
            foreach (var basicLevelViewer in basicLevelViewers)
            {
                basicLevelViewer.OnClick += OpenDetailedLevelViewByIndex;
            }
        }

        private void OpenDetailedLevelViewByIndex(int index) 
        {
            Dependencies.Instance.LevelsModel.CurrentLevel = levels[index];
            (detailedLevelViewer as IDetailedLevelViewer).ActivateDetailedLevelViewer(levels[index]);
        }
    }
}
