using Gameplay.Unit.UnitAI;
using UnityEngine;
using UnityEngine.Events;

namespace Gameplay.Unit.Health
{
    public class HealthComponent : MonoBehaviour, IDamageReceiver
    {
        [SerializeField] private HealthStatsSO healthStats;
        //TODO: remove if decided on no hp  [SerializeField] private Healthbar healthbar;

        public UnityEvent OnDamageTaken;
        public UnityEvent<UnitState> OnDeath;
        
        private float currentHealth;
        //Todo: Possibly make private
        public float CurrentHealth
        {
            get => currentHealth;
            private set
            {
                if (value <= 0)
                {
                    OnDeath?.Invoke(UnitState.Death);
                }
                
                currentHealth = Mathf.Clamp(value, 0, healthStats.MaxHealth);
                //TODO: remove if decided on no hp healthbar.UpdateHealthbar(currentHealth, healthStats.MaxHealth);
            }
        }

        void OnEnable()
        {
            OnDeath.AddListener((UnitState) =>
            {
                GetComponent<UnitAI.UnitAI>().enabled = false;
                GetComponent<BoxCollider>().enabled = false;
            });
            currentHealth = healthStats.MaxHealth;
        }


        public void TakeDamage(float value)
        {
            CurrentHealth -= value;
           //TODO: remove if decided on no hp healthbar.UpdateHealthbar(currentHealth, healthStats.MaxHealth);
            
           // Prevent the onDamageTaken event from firing in the case of the player being healed.
           if (value > 0)
                OnDamageTaken?.Invoke();
        }

        public void SubscribeToOnDeath(UnityAction<UnitState> method)
        {
            OnDeath.AddListener(method);
        }
    }
}
