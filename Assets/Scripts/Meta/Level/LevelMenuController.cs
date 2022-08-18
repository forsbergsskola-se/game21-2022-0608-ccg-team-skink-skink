using System;
using Meta.Interfaces;
using UnityEngine;
using Utility;
using Object = UnityEngine.Object;

namespace Meta.Level
{
    public class LevelMenuController : MonoBehaviour
    {
        [SerializeField, RequireInterface(typeof(ILevel))] private Object[] levelsInOrder;

        [SerializeField, RequireInterface(typeof(IDetailedLevelViewer))] private Object detailedLevelViewer;

        private ILevel[] levels;

        private void Awake()
        {
            levels = Array.ConvertAll(levelsInOrder, input => input as ILevel);

            var basicLevelViewers = GetComponentsInChildren<IBasicLevelViewer>();
            foreach (var basicLevelViewer in basicLevelViewers)
            {
                basicLevelViewer.OnClick += OpenDetailedLevelViewByIndex;
            }
        }

        private void OpenDetailedLevelViewByIndex(int index)
        {
            Dependencies.Instance.LevelsModel.SetCurrentLevel(levels[index], index);
            (detailedLevelViewer as IDetailedLevelViewer).ActivateDetailedLevelViewer(levels[index]);
        }
    }
}
