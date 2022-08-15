using System;
using Meta.Interfaces;

namespace Meta.Relays
{
    public class EndOfGameRelay : IEndOfGame
    {
        public void OnGameEnded(bool userWon)
        {
            if (userWon)
                OnWin?.Invoke();
            else
                OnLose?.Invoke();
        }

        public event Action OnWin;

        public event Action OnLose;
    }
}
