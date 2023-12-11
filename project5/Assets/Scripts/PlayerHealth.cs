using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public int maxHealth = 100; // �÷��̾��� �ִ� ü��
    private int currentHealth; // ���� ü��

    private void Start()
    {
        currentHealth = maxHealth; // ������ �� �ִ� ü������ �ʱ�ȭ
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage; // ü�� ����

        if (currentHealth <= 0)
        {
            Die(); // ü���� 0 ������ ��� ��� ó��
        }
    }

    private void Die()
    {
        // ��� ó�� ������ �ۼ��ϼ���.
    }
}
