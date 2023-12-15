using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class chsOutdoorFireSpawn : MonoBehaviour
{
    public GameObject VFX_Fire_01_Big;
    private Vector3 spawnOrigin = new Vector3(219, 90, 583); // ?? ???? ???? ????
    private float spawnInterval = 10.0f;

    void Start()
    {
        Invoke("SpawnFire", spawnInterval); // ???? ???? ?? 3?? ?????? ?? Fire ????
    }

    void SpawnFire()
    {
        if (cshOutdoorCall.isSurvived)
            return;

        float randomX = Random.Range(-200f, 300f);
        float randomY = Random.Range(-100f, 0f);
        float randomZ = Random.Range(-600f, 500f);

        Vector3 spawnPosition = spawnOrigin + new Vector3(randomX, randomY, randomZ); // ?? ???? ???? ?????? ???????? ???? ???? ????

        GameObject fire = Instantiate(VFX_Fire_01_Big, spawnPosition, Quaternion.identity);
        fire.tag = "Fire";

        // 생성된 불 인스턴스를 리스트에 추가
        cshOutdoorCall.fires.Add(fire);

        Invoke("SpawnFire", spawnInterval);
    }

    void OnCollisionEnter(Collision collision)
    {
        GameObject collidedObject = collision.gameObject;

        if (collidedObject.tag == "Player")
        {
            HealthBarController playerHP = collidedObject.GetComponent<HealthBarController>();
            playerHP.DecreaseHealth(30.0f);
        }
    }
}