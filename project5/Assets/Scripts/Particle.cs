using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayParticlesOnTrigger : MonoBehaviour
{
    public ParticleSystem confettiParticles; // 파티클 시스템 참조

    // 플레이어와의 트리거 이벤트를 감지합니다.
    void OnTriggerEnter(Collider other)
    {

        // 트리거 이벤트가 발생한 오브젝트의 태그가 'Player'인지 확인합니다.
        if (other.gameObject.CompareTag("Player"))
        {
            // 파티클 재생
            confettiParticles.Play();
            Debug.Log("Collision Detected with " + other.gameObject.name);
        }
    }
}
