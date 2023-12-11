using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireSpawner : MonoBehaviour
{
    public GameObject VFX_Fire_01_Medium;
    private Vector3 spawnOrigin = new Vector3(-3, 1, 7); // ù ���� �ʱ� ��ǥ
    private float spawnInterval = 3.0f;

    void Start()
    {
        Invoke("SpawnFire", spawnInterval); // ���� ���� �� 3�� ���Ŀ� ù Fire ����
    }

    void SpawnFire()
    {
        float randomX = Random.Range(-1f, 1f);
        float randomY = Random.Range(-1f, 1f);
        float randomZ = Random.Range(-1f, 1f);

        Vector3 spawnPosition = spawnOrigin + new Vector3(randomX, randomY, randomZ); // ù ���� �ʱ� ��ǥ�� �������� ���� ��ǥ ����

        GameObject fire = Instantiate(VFX_Fire_01_Medium, spawnPosition, Quaternion.identity);
        fire.tag = "Fire";

        Invoke("SpawnFire", spawnInterval); // ���� Fire�� ���� Fire�� ������ �� 3�� �Ŀ� ����
    }

    void OnCollisionEnter(Collision collision)
    {
        GameObject collidedObject = collision.gameObject;

        if (collidedObject.tag == "Player")
        {
            HealthBarController playerHP = collidedObject.GetComponent<HealthBarController>();
            playerHP.DecreaseHealth(10.0f);
        }
    }
}
