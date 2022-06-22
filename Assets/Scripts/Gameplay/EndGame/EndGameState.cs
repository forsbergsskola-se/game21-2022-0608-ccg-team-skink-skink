using System;
using UnityEngine;
using UnityEngine.Events;

namespace Gameplay.EndGame
{
    [CreateAssetMenu(menuName = "ScriptableObjects/Utilities/EndGameState", fileName = "NewEndGameState")]
    public class EndGameState : ScriptableObject
    {
        private UnityEvent win;
        private UnityEvent lose;

        public void WinInvoke() => win.Invoke();
        public void LoseInvoke() => lose.Invoke();

        public void SubscribeWin(UnityAction method) => win.AddListener(method);
        public void SubscribeLose(UnityAction method) => lose.AddListener(method);

        public void SubscribeEndGame(UnityAction method)
        {
            SubscribeWin(method);
            SubscribeLose(method);
        }
    }
}
