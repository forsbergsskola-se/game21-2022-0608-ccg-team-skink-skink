using System;

namespace Meta.Interfaces
{
    /// <summary>
    /// Interface for 
    /// </summary>
    public interface IAdSystem
    {
        public interface IAd
        {
            /// <summary>
            /// Plays the ad for the user
            /// </summary>
            public void PlayAd();
        }
    
        public interface IAdController
        {
            /// <summary>
            /// Called upon when ad has finished playing
            /// </summary>
            public event Action OnAdCompleted;

            /// <summary>
            /// Gets an ad object
            /// </summary>
            /// <returns></returns>
            public IAd GetAd();
        }
    }
}