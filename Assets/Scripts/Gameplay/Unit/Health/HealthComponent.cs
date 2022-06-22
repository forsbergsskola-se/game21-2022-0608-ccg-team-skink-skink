using UnityEngine;
using UnityEngine.Events;

namespace Gameplay.Unit.Health
{
    public class HealthComponent : MonoBehaviour, IDamageReceiver
    {
        [SerializeField] private HealthStatsSO healthStats;

        public UnityEvent OnDamageTaken;
        public UnityEvent OnDeath;

        private float currentHealth;
        //Todo: Possibly make private
        public float CurrentHealth
        {
            get => currentHealth;
            private set
            {
                if (value <= 0)
                {
                    OnDeath?.Invoke();
                    gameObject.SetActive(false);
                }
                    
                currentHealth = Mathf.Clamp(value, 0, healthStats.MaxHealth);
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

        public void SubscribeToOnDeath(UnityAction method)
        {
            OnDeath.AddListener(method);
        }
    }
}
