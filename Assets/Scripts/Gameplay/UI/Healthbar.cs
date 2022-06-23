using System.Collections;
using System.Collections.Generic;
using Gameplay.Unit;
using Gameplay.Unit.Health;
using UnityEngine;
using UnityEngine.UI;

public class Healthbar : MonoBehaviour
{
    [SerializeField] private Image healthbarImage;

    public void UpdateHealthbar(float currentHealth, float maxHealth)
    {
        healthbarImage.fillAmount = currentHealth / maxHealth;
    }
}
