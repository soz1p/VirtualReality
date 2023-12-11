using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public int maxHealth = 100; // 플레이어의 최대 체력
    private int currentHealth; // 현재 체력

    private void Start()
    {
        currentHealth = maxHealth; // 시작할 때 최대 체력으로 초기화
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage; // 체력 감소

        if (currentHealth <= 0)
        {
            Die(); // 체력이 0 이하일 경우 사망 처리
        }
    }

    private void Die()
    {
        // 사망 처리 로직을 작성하세요.
    }
}
