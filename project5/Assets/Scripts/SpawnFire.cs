using System.Collections;
using UnityEngine;

public class SpawnFire : MonoBehaviour
{
    public GameObject VFX_Fire_01_Big_Smoke; // Fire의 Prefab을 Inspector에서 지정해주세요.
    private Vector3 startPosition = new Vector3(-3f, 1.5f, 6.5f);

    void Start()
    {
        StartCoroutine(SpawnAfterDelay());
    }

    IEnumerator SpawnAfterDelay()
    {
        yield return new WaitForSeconds(1f); // 5초 대기

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
            newFire.SetActive(false); // 생성 즉시 비활성화

            yield return new WaitForSeconds(1f); // 5초 대기

            newFire.SetActive(true); // 5초 후 활성화

            yield return new WaitForSeconds(1f); // 다음 Fire 생성까지 1초 대기
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            PlayerHealth playerHealth = other.GetComponent<PlayerHealth>();
            if (playerHealth != null)
            {
                playerHealth.TakeDamage(100); // 플레이어의 체력을 10만큼 감소시킴
            }
        }

    }
}
