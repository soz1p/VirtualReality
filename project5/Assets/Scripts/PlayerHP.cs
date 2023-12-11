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

        StartCoroutine(AutoDecreaseHP());
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
            // HP가 0 이하가 되면, 플레이어는 죽습니다. 이 부분은 게임에 따라 적절히 수정하시면 됩니다.
            Debug.Log("Player is dead");
        }
    }
    private IEnumerator AutoDecreaseHP()
    {
        while (true)
        {
            DecreaseHealth(decreaseAmount / 10);
            yield return new WaitForSeconds(2f);
        }
    }
}
