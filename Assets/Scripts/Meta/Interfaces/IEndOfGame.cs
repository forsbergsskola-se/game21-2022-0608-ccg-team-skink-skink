using System;

public interface IEndOfGame
{
    public void OnGameEnded(bool userWon);

    internal event Action OnWin;
    internal event Action OnLose;
}