using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class cshOutdoorPlayerHP : MonoBehaviour
{
    public Slider healthBar;
    public float maxHealth = 1000f;
    public float decreaseAmount = 20f;

    private float currentHealth;
    private Image healthBarFillImage; // 추가: 슬라이더의 Fill Area에 있는 Image 컴포넌트

    private void Start()
    {
        currentHealth = maxHealth;
        healthBar.maxValue = maxHealth;
        healthBar.value = currentHealth;

        healthBarFillImage = healthBar.fillRect.GetComponent<Image>(); // 추가: Image 컴포넌트 참조 가져오기

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

        // 추가: 체력에 따라 그라데이션 색상으로 표시
        healthBarFillImage.color = Color.Lerp(Color.red, Color.green, currentHealth / maxHealth);

        if (currentHealth <= 0)
        {
            Debug.Log("Player is dead");
        }
    }

    private IEnumerator AutoDecreaseHP()
    {
        while (true)
        {
            DecreaseHealth(decreaseAmount / 10);
            yield return new WaitForSeconds(1f);
        }
    }
}
