using UnityEngine;

public abstract class EnemyCommon : MonoBehaviour
{
    protected SpriteRenderer sprite;
    protected Animator animator;
    [SerializeField] protected Collider2D hitBox;

    protected AudioSource audioSource;
    [SerializeField] protected AudioClip attackSound;
    [SerializeField] protected AudioClip hurtSound;


    public const string 
        ATTACK = "attack",
        DIE = "die",
        HURT = "hurt";

    protected bool attack;
    protected bool isAttacking;
    protected bool dead;
    protected float speed;

    public const float BASE_SPEED = 2f;

    protected int direction;
    public const int 
        LEFT = -1,
        RIGHT = 1;

    protected void Start() {
        sprite = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
        audioSource = GetComponent<AudioSource>();
        direction = LEFT;
        attack = false;
        dead = false;
    }

    public void ApplyMovement() {
        transform.position = new Vector2(
            transform.position.x + direction * speed * Time.deltaTime,
            transform.position.y);
    }
    public void AttackEnd()
    {
        isAttacking = false;
    }

    public bool IsAttacking() {
        return isAttacking;
    }

    public void setDirection(int direction) {
        this.direction = direction;
    }

    protected void Die() {
        attack = false;
        dead = true;
        speed = 0;
        HeroGameController.enemiesKilled++;
        hitBox.gameObject.SetActive(false);
        audioSource.PlayOneShot(hurtSound);
        Destroy(gameObject, 1.5f);
    }

    public Animator getAnimator() {
        return animator;
    }

    public abstract void HeroInSight();
    public abstract void HeroOutOfSight();
    public abstract void HeroInRange();
    public abstract void HeroOutOfRange();
    public abstract void Hurt();
}
