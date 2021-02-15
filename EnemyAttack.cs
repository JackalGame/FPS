using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    [SerializeField] int damage = 20;

    PlayerHealth target;

    void Start()
    {
        target = FindObjectOfType<PlayerHealth>();
    }

    public void AttackHitEvent()
    {
        if (target == null) return;
        target.GetComponent<PlayerHealth>().DamageDealer(damage);
        target.GetComponent<DisplayDamage>().ShowDamageCanvas();
    }
}
