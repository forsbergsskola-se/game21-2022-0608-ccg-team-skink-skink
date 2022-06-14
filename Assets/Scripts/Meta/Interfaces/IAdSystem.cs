using System;

namespace Meta.Interfaces
{
    public interface IAdSystem
    {
        public interface IAd
        {
            public void PlayAd();
        }
    
        public interface IAdController
        {
            public event Action OnAdCompleted;

            public IAd GetAd();
        }
    }
}