using UnityEngine;
using UnityEngine.Events;

namespace Gameplay.Unit.Health
{
    public class HealthComponent : MonoBehaviour, IDamageReceiver
    {
        [SerializeField] private HealthStats healthStats;

        public UnityEvent OnDamageTaken;
        public UnityEvent OnDeath;

    
    
        private float currentHealth;
        public float CurrentHealth
        {
            get => currentHealth;
            private set
            {
                if (value <= 0)
                    OnDeath?.Invoke();

                currentHealth = value;
            }
        }
    
    
    
        void OnEnable()
        {
            currentHealth = healthStats.MaxHealth;
        }
    
    
    
        public void TakeDamage(float value)
        {
            CurrentHealth -= value;
        
            // Prevent the onDamageTaken event from firing in the case of the player being healed.
            if (value > 0)
                OnDamageTaken?.Invoke();
        }
    }
}
