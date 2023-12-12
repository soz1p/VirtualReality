using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayParticlesOnTrigger : MonoBehaviour
{
    public ParticleSystem confettiParticles; // ��ƼŬ �ý��� ����

    // �÷��̾���� Ʈ���� �̺�Ʈ�� �����մϴ�.
    void OnTriggerEnter(Collider other)
    {

        // Ʈ���� �̺�Ʈ�� �߻��� ������Ʈ�� �±װ� 'Player'���� Ȯ���մϴ�.
        if (other.gameObject.CompareTag("Player"))
        {
            // ��ƼŬ ���
            confettiParticles.Play();
            Debug.Log("Collision Detected with " + other.gameObject.name);
        }
    }
}
