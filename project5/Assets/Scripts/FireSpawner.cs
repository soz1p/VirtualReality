using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireSpawner : MonoBehaviour
{
    public GameObject VFX_Fire_01_Medium;
    private Vector3 spawnOrigin = new Vector3(-3, 1, 7); // 첫 스폰 초기 좌표
    private float spawnInterval = 3.0f;

    void Start()
    {
        Invoke("SpawnFire", spawnInterval); // 게임 시작 후 3초 이후에 첫 Fire 생성
    }

    void SpawnFire()
    {
        float randomX = Random.Range(-1f, 1f);
        float randomY = Random.Range(-1f, 1f);
        float randomZ = Random.Range(-1f, 1f);

        Vector3 spawnPosition = spawnOrigin + new Vector3(randomX, randomY, randomZ); // 첫 스폰 초기 좌표를 기준으로 랜덤 좌표 생성

        GameObject fire = Instantiate(VFX_Fire_01_Medium, spawnPosition, Quaternion.identity);
        fire.tag = "Fire";

        Invoke("SpawnFire", spawnInterval); // 다음 Fire는 이전 Fire가 생성된 후 3초 후에 생성
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
