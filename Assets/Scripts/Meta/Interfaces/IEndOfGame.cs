using System;

namespace Meta.Interfaces
{
    public interface IEndOfGame
    {
        public void OnGameEnded(bool userWon);

        public event Action OnWin;
        public event Action OnLose;
    }
}