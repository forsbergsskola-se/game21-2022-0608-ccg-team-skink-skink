using Gameplay.Unit.UnitAI;
using UnityEngine;
using UnityEngine.Events;

namespace Gameplay.Unit.Health
{
    public class HealthComponent : MonoBehaviour, IDamageReceiver
    {
        [SerializeField] private HealthStatsSO healthStats;
        //TODO: remove if decided on no hp  [SerializeField] private Healthbar healthbar;
        
        public HealthStatsSO HealthStats => healthStats;

        public UnityEvent OnDamageTaken;
        public UnityEvent<UnitState> OnDeath;
        
        private float currentHealth;
        //Todo: Possibly make private
        public float CurrentHealth
        {
            get => currentHealth;
            private set
            {
                if (value <= 0) OnDeath?.Invoke(UnitState.Death);
                
                currentHealth = Mathf.Clamp(value, 0, healthStats.MaxHealth);
                //TODO: remove if decided on no hp healthbar.UpdateHealthbar(currentHealth, healthStats.MaxHealth);
            }
        }

        void OnEnable()
        {
            OnDeath.AddListener((UnitState) =>
            {
                if (TryGetComponent(out Ai.UnitAI unitAI)) unitAI.enabled = false;
                if (TryGetComponent(out BoxCollider boxCollider)) boxCollider.enabled = false;
            });
            currentHealth = healthStats.MaxHealth;
        }


        public void TakeDamage(float value)
        {
            CurrentHealth -= value;
            //TODO: remove if decided on no hp healthbar.UpdateHealthbar(currentHealth, healthStats.MaxHealth);
        }

        public void SubscribeToOnDeath(UnityAction<UnitState> method) => OnDeath.AddListener(method);
    }
}
