using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    HeroGameController hero;

    private void Start()
    {
        hero = FindObjectOfType<HeroGameController>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == Layers.HERO) {
            hero.Die();
        }
    }
}
