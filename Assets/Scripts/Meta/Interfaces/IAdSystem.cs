using System;

public interface IAdSystem
{
    public interface IAdController
    {
        public event Action OnAdCompleted;
    }
    public interface IAd
    {
        public void PlayAd();
    }
}
