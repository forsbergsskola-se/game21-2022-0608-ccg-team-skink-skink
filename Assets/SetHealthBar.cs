using System;
using Gameplay.Unit.Health;
using UnityEngine;
using UnityEngine.UI;

public class SetHealthBar : MonoBehaviour
{
    public Slider slider;
    public Gradient gradient;
    public HealthComponent HealthComponent;
    public Image fill;

    private void Start()
    {
        slider.maxValue = HealthComponent.HealthStats.MaxHealth;
        
        UpdateHealthBar();
        HealthComponent.OnDamageTaken.AddListener(UpdateHealthBar);
    }

    private void UpdateHealthBar()
    {
        slider.value = HealthComponent.CurrentHealth;
        fill.color = gradient.Evaluate(slider.normalizedValue);
    }
}
