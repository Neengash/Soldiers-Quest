using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InRangeEnemyTrigger : MonoBehaviour
{
    [SerializeField] EnemyCommon enemy;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == Layers.HERO)
        {
            enemy.HeroInRange();
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.layer == Layers.HERO)
        {
            enemy.HeroOutOfRange();
        }
    }
}
