using System;
using System.Collections;
using Meta.Interfaces;
using UnityEngine;
using Utility;

namespace Meta.LoadSave
{
    public class LoadSaveManager : MonoBehaviour
    {
        [SerializeField] private float waitTime;
        
        [SerializeField] private CardArraySO cardArray;

        private GameState state = new ();
        private LoadState loadState;
        private SaveState saveState;

        private void Awake()
        {
            loadState = new LoadState(cardArray);
            saveState = new SaveState(cardArray);
            
            state = loadState.Load();
            saveState.Save(state);


            Dependencies.Instance.Inventory.CardAdded += (ICard card) => Save();
            Dependencies.Instance.Inventory.CardRemoved += (ICard card) => Save();
            Dependencies.Instance.LevelsModel.MaxLevelIndexChanged += (int i) => Save();
            Dependencies.Instance.PlayerCardHand.HandChanged += (int i, ICard card) => Save();
            Dependencies.Instance.NormalCoinCarrier.ValueChanged += (int i) => Save();
            Dependencies.Instance.LootBoxAmountModel.ValueChanged += (int i) => Save();
        }

        private void Save()
        {
            StopAllCoroutines();
            StartCoroutine(WaitThanSave());
        }

        private IEnumerator WaitThanSave()
        {
            yield return new WaitForSeconds(waitTime);
            saveState.Save(state);
        }

        private void OnDestroy() => saveState.Save(state);
    }
}
