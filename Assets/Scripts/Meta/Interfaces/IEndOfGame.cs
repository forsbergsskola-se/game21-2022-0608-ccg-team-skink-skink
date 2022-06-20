using System;

namespace Meta.Interfaces
{
    /// <summary>
    /// Interface for EndOfGame relays.
    /// </summary>
    public interface IEndOfGame
    {
        /// <summary>
        /// Called by the gameplay when the game has ended. Triggers the OnWin/OnLose events.
        /// </summary>
        /// <param name="userWon"></param>
        public void OnGameEnded(bool userWon);

        /// <summary>
        /// Triggered if the game ended with the user being the winner.
        /// </summary>
        public event Action OnWin;
        
        /// <summary>
        /// Triggered if the game ended with the ai being the winner.
        /// </summary>
        public event Action OnLose;
    }
}