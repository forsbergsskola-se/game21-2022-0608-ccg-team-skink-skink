using System;
using System.Collections;
using System.Collections.Generic;
using Gameplay.Unit.Health;
using UnityEngine;
using UnityEngine.UI;

public class SetHealthBar : MonoBehaviour
{
    public Slider slider;
    public HealthComponent HealthComponent;


    private void Update()
    {
        UpdateHealthbar();
    }

    public void SetMaxHealth(int health)
    {
        slider.maxValue = health;
        slider.value = health;
    }

    public void SetHealth(int health)
    {
        slider.value = health;
    }

    public void UpdateHealthbar()
    {
        slider.value = HealthComponent.CurrentHealth;
    }
}
