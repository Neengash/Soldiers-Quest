using UnityEngine;

public class DoubleJumpBoost : MonoBehaviour
{
    HeroGameController hero;

    AudioSource audioSource;
    [SerializeField] AudioClip coinSound;

    Collider2D collider;
    GameObject child;

    const int INCREMENT = 5;

    float ydiff;
    int direction;
    const float Y_INCREMENT = 0.015f;
    const float Y_MAX = 0.3f;
    const float Y_MIN = -Y_MAX;
    const int UP = 1;
    const int DOWN = -1;

    float startX, startY;

    void Start()
    {
        hero = FindObjectOfType<HeroGameController>();
        audioSource = GetComponent<AudioSource>();
        collider = GetComponent<Collider2D>();
        child = gameObject.transform.GetChild(0).gameObject;
        direction = UP;
        ydiff = 0;
        startX = transform.position.x;
        startY = transform.position.y;
    }

    private void Update()
    {
        ydiff += direction * Y_INCREMENT;

        if (ydiff > Y_MAX) {
            ydiff = Y_MAX;
            direction = DOWN;
        }

        if (ydiff < Y_MIN) {
            ydiff = Y_MIN;
            direction = UP;
        }

        transform.position = new Vector2(startX, startY + ydiff);
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == Layers.HERO)
        {
            HeroGameController.doubleJumpsAvailable += INCREMENT;
            audioSource.PlayOneShot(coinSound);
            collider.enabled = false;
            child.SetActive(false);
            Destroy(gameObject, 1f);
        }
    }
}
