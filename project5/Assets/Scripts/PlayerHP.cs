using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class HealthBarController : MonoBehaviour
{
    public Slider healthBar;
    public float maxHealth = 10000f;
    public float decreaseAmount = 500f;

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
            Debug.Log("Player is dead");
            SceneManager.LoadScene("DeadScene");
        }
    }
    private IEnumerator AutoDecreaseHP()
    {
        while (true)
        {
            var decreaseRate = Input.GetKey(KeyCode.LeftControl) ? decreaseAmount / 50 : decreaseAmount / 5;
            DecreaseHealth(decreaseRate);
            yield return new WaitForSeconds(2f);
        }
    }
}
