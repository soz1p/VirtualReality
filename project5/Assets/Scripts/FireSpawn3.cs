using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireSpawner1 : MonoBehaviour
{
    public GameObject VFX_Fire_01_Medium;
    public GameObject VFX_Fire_01_Big_Smoke;
    public GameObject VFX_Fire_Floor_01;
    private Vector3 spawnOrigin1 = new Vector3(-4, 0, -2); // ù ���� �ʱ� ��ǥ
    private float spawnInterval1 = 3.0f;

    void Start()
    {
        InvokeRepeating("SpawnFire", spawnInterval1, spawnInterval1); // ���� ���� �� 3�� ���Ŀ� ù Fire ����, �� ���Ŀ��� 3�� ���� Fire ����
    }

    void SpawnFire()
    {
        float randomX = Random.Range(-2f, 2f);
        float randomY = Random.Range(0f, 0.2f);
        float randomZ = Random.Range(-2f, 2f);

        Vector3 spawnPosition = spawnOrigin1 + new Vector3(randomX, randomY, randomZ); // ù ���� �ʱ� ��ǥ�� �������� ���� ��ǥ ����

        GameObject fire;

        if (spawnPosition.y == 0) // Y ��ǥ�� 0�� ���
        {
            fire = Instantiate(VFX_Fire_Floor_01, spawnPosition, Quaternion.identity); // VFX_Fire_Floor_01_Smoke ����
        }
        else
        {
            float randomFireSize = Random.Range(0f, 1f);
            if (randomFireSize < 0.8f)
                fire = Instantiate(VFX_Fire_01_Medium, spawnPosition, Quaternion.identity);
            else
                fire = Instantiate(VFX_Fire_01_Big_Smoke, spawnPosition, Quaternion.identity);
        }

        fire.tag = "Fire";
        spawnOrigin = spawnPosition;
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
