using System;
using System.Collections;
using System.Collections.Generic;
using Gameplay.Unit;
using Meta.Interfaces;
using UnityEngine;
using UnityEngine.Events;

public class HealthComponent : MonoBehaviour, IDamageReciver
{
    public UnityEvent OnDamageTaken;
    public float CurrentHealth { get; private set; }
    private HealthStats healthStats;
    

    void OnEnable()
    {
        CurrentHealth = healthStats.MaxHealth;
    }
    
    public void TakeDamage(float value)
    {
        CurrentHealth -= value;
        OnDamageTaken?.Invoke();
    }
}
