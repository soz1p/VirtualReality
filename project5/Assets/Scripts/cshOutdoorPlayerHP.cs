using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class cshOutdoorPlayerHP : MonoBehaviour
{
    public Slider healthBar;
    public float maxHealth = 500f;
    public float decreaseAmount = 30f;

    private float currentHealth;
    private Image healthBarFillImage; // ??: ????? Fill Area? ?? Image ????

    private void Start()
    {
        currentHealth = maxHealth;
        healthBar.maxValue = maxHealth;
        healthBar.value = currentHealth;

        healthBarFillImage = healthBar.fillRect.GetComponent<Image>(); // ??: Image ???? ?? ????

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

        // ??: ??? ?? ????? ???? ??
        healthBarFillImage.color = Color.Lerp(Color.red, Color.green, currentHealth / maxHealth);

        if (currentHealth <= 0)
        {
            Debug.Log("Player is dead");
            SceneManager.LoadScene("OutdoorDeadScene");
        }
    }

    private IEnumerator AutoDecreaseHP()
    {
        while (!cshOutdoorCall.isSurvived) // isSurvived? false? ?? ?? ??
        {
            DecreaseHealth(decreaseAmount / 50);
            yield return new WaitForSeconds(0.075f);
        }
    }
}