using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBarController : MonoBehaviour
{
    public Slider healthBar;
    public float maxHealth = 1000f;
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
        if (other.CompareTag("Fire"))
        {
            DecreaseHealth(decreaseAmount);
        }
    }

    public void DecreaseHealth(float amount)
    {
        currentHealth -= amount;
        healthBar.value = currentHealth;

        if (currentHealth <= 0)
        {
            // HP�� 0 ���ϰ� �Ǹ�, �÷��̾�� �׽��ϴ�. �� �κ��� ���ӿ� ���� ������ �����Ͻø� �˴ϴ�.
            Debug.Log("Player is dead");
        }
    }
}
