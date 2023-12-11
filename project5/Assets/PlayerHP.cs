using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBarController : MonoBehaviour
{
    public Slider healthBar;
    public float maxHealth = 100f;
    public float decreaseAmount = 10f;

    private float currentHealth;

    private void Start()
    {
        currentHealth = maxHealth;
        healthBar.maxValue = maxHealth;
        healthBar.value = currentHealth;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("fire"))
        {
            DecreaseHealth(decreaseAmount);
        }
    }

    private void DecreaseHealth(float amount)
    {
        currentHealth -= amount;
        healthBar.value = currentHealth;
    }
}
