using System;
using Meta.Interfaces;
using UnityEngine;

public class EndOfGameRelay : MonoBehaviour, IEndOfGame
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
