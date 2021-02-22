using UnityEngine;

public class PatrollEnemy : EnemyCommon
{
    [SerializeField] Collider2D leftLimit;
    [SerializeField] Collider2D rightLimit;

    [SerializeField] GameObject leftAttack;
    [SerializeField] GameObject rightAttack;

    [SerializeField] GameObject leftSight;
    [SerializeField] GameObject rightSight;


    protected new void Start()
    {
        base.Start();
        sprite.flipX = false;
        direction = LEFT;
        speed = BASE_SPEED;
        leftSight.SetActive(true);
        rightSight.SetActive(false);
    }

    private void Update()
    {
        if (attack) {
            animator.SetBool(ATTACK, true);
            isAttacking = true;
        } else {
            animator.SetBool(ATTACK, false);
        }
        
        if (dead) {
            animator.SetBool(DIE, true);
        }
    }

    private void FixedUpdate()
    {
        if (!isAttacking && !dead) {
            CheckPatrollLimits();
            ApplyMovement();
        }
    }

    public override void HeroInRange() {
        attack = true;
        isAttacking = true;
    }

    public override void HeroOutOfRange() {
        attack = false;
    }

    public override void Hurt()
    {
        Die();
    }

    public void ActivateAttack()
    {
        audioSource.PlayOneShot(attackSound);
        if (direction == LEFT) {
            leftAttack.SetActive(true);
        } else {
            rightAttack.SetActive(true);
        }
    }

    public void DeactivateAttack()
    {
        leftAttack.SetActive(false);
        rightAttack.SetActive(false);
    }

    private void CheckPatrollLimits()
    {
        if (
            leftLimit.IsTouching(hitBox) ||
            rightLimit.IsTouching(hitBox)
        ) {
            ChangeDirection();
        }
    }
    public void ChangeDirection()
    {
        direction = (direction == LEFT) ? RIGHT : LEFT;
        sprite.flipX = !sprite.flipX;

        leftSight.SetActive(direction == LEFT);
        rightSight.SetActive(direction == RIGHT);
    }

    public override void HeroInSight()
    {
        // This type of enemy doesn't use sight
    }

    public override void HeroOutOfSight()
    {
        // This type of enemy doesn't use sight
    }
}
