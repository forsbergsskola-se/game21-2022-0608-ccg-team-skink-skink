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
                    OnDeath?.Invoke();

                currentHealth = value;
            }
        }
    
    
    
        void OnEnable()
        {
            currentHealth = healthStats.MaxHealth;
        }

        void Hit(float damageAmount)
        {
            //TODO:Clean up debug
            Debug.Log($"{this.name} is getting attacked");
            Debug.Log(currentHealth);
            
            CurrentHealth -= damageAmount;
            
            Debug.Log(currentHealth);
        
            // Prevent the onDamageTaken event from firing in the case of the player being healed.
            if (damageAmount > 0)
                OnDamageTaken?.Invoke();
        }
    
    
        public void TakeDamage(float value)
        {
            Hit(value);
        }
    }
}
