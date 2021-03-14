using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField] float hp = 100f;
    [SerializeField] AudioClip damageSFX;

    bool isDead = false;
    AudioSource audioSource;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    public bool IsDead()
    {
        return isDead;
    }

    public void TakeDamage(float damage)
    {
        if (isDead) return;
        BroadcastMessage("OnDamageTaken");
        hp -= damage;
        audioSource.PlayOneShot(damageSFX, 1);
        if(hp <= 0)
        {
            Die();
            FindObjectOfType<OpeningVillage>().DecreaseEnemiesRemaining();
        }
    }

    public void Die()
    {
        if (isDead) return;
        isDead = true;
        GetComponent<AudioSource>().Stop();
        GetComponent<Animator>().SetTrigger("dead");
        GetComponent<CapsuleCollider>().enabled = false;
    }
}
