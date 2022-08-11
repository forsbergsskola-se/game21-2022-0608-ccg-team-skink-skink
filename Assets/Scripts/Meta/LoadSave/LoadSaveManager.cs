using UnityEngine;
using Utility;

namespace Meta.LoadSave
{
    public class LoadSaveManager : MonoBehaviour
    {
        [SerializeField] private CardArraySO cardArray;

        private GameState state = new ();
        private LoadState loadState;
        private SaveState saveState;

        private void Awake()
        {
            loadState = new LoadState(state, cardArray);
            loadState.Load();
        }
    }
}
