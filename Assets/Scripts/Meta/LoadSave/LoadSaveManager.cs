using UnityEngine;
using Utility;

namespace Meta.LoadSave
{
    public class LoadSaveManager : MonoBehaviour
    {
        [SerializeField] private CardArraySO cardArray;

        private GameState gameState = new GameState();
        private LoadState loadState = new LoadState();
        private SaveState saveState = new SaveState();
    }
}
