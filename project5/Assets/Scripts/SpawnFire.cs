using System.Collections;
using UnityEngine;

public class SpawnFire : MonoBehaviour
{
    public GameObject VFX_Fire_01_Big_Smoke; // Fire�� Prefab�� Inspector���� �������ּ���.
    private Vector3 startPosition = new Vector3(-3f, 1.5f, 6.5f);

    void Start()
    {
        StartCoroutine(SpawnAfterDelay());
    }

    IEnumerator SpawnAfterDelay()
    {
        yield return new WaitForSeconds(1f); // 5�� ���

        StartCoroutine(Spawn());
    }

    IEnumerator Spawn()
    {
        while (true)
        {
            float randomX = Random.Range(-1f, 1f);
            float randomZ = Random.Range(-1f, 1f);

            Vector3 spawnPosition = new Vector3(startPosition.x + randomX, startPosition.y, startPosition.z + randomZ);

            GameObject newFire = Instantiate(VFX_Fire_01_Big_Smoke, spawnPosition, Quaternion.identity);
            newFire.tag = "Fire";
            newFire.SetActive(false); // ���� ��� ��Ȱ��ȭ

            yield return new WaitForSeconds(1f); // 5�� ���

            newFire.SetActive(true); // 5�� �� Ȱ��ȭ

            yield return new WaitForSeconds(1f); // ���� Fire �������� 1�� ���
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            PlayerHealth playerHealth = other.GetComponent<PlayerHealth>();
            if (playerHealth != null)
            {
                playerHealth.TakeDamage(100); // �÷��̾��� ü���� 10��ŭ ���ҽ�Ŵ
            }
        }

    }
}
