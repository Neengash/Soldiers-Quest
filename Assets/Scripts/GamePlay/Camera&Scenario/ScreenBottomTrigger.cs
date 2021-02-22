using UnityEngine;

public class ScreenBottomTrigger : MonoBehaviour
{
    HeroGameController hero;

    void Start()
    {
        hero = FindObjectOfType<HeroGameController>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == Layers.HERO)
        {
            hero.Die();
        }
    }
}
