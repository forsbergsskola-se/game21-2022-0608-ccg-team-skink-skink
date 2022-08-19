using System.Collections;
using Meta.Interfaces;
using UnityEngine;
using Utility;
using Object = UnityEngine.Object;

namespace Meta.LoadSave
{
    public class LoadSaveManager : MonoBehaviour
    {
        [SerializeField] private float waitTime;
        
        [Header("Dependencies")]
        [SerializeField] private CardArraySO cardArray;
        [SerializeField, RequireInterface(typeof(ICardHand))] private Object starterCardHand;

        private LoadState loadState;
        private SaveState saveState;

        public static LoadSaveManager Instance { get; private set; }
        
        private void Awake()
        {
            if (Instance != null && Instance != this)
            {
                Destroy(gameObject);
                return;
            }

            Instance = this;
            DontDestroyOnLoad(gameObject);

            Debug.Log("Start file read in saveManager");
            loadState = new LoadState(cardArray, starterCardHand as ICardHand);
            loadState.Load();
            
            saveState = new SaveState(cardArray);
            
            SubscribeToDependencies();
        }

        private void SubscribeToDependencies()
        {
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
            saveState.Save();
        }

        // private void OnDestroy() => saveState.Save();
    }
}
