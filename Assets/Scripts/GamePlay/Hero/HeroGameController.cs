using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeroGameController : MonoBehaviour
{
    public bool isDead;

    [SerializeField] public static int doubleJumpsAvailable;
    public static int enemiesKilled;

    public bool isAttacking;
    bool attackCombo;
    [SerializeField] Collider2D leftAttack;
    [SerializeField] Collider2D rightAttack;

    Collider2D hitBox;
    Rigidbody2D rbody2D;

    AudioSource audioSource;
    [SerializeField] AudioClip swordAttack;
    [SerializeField] AudioClip deathSound;

    bool jump;
    bool jumpReleased;
    public bool onFloor;
    bool hasDoubleJumped;
    const float JUMP_VELOCITY = 5.5f;

    bool moveLeft;
    bool moveRight;
    int direction;
    const int RIGHT = 1;
    const int LEFT = -1;
    public const float BASE_SPEED = 3f;

    PauseController game;
    GameOverController gameOver;
    GameClearController gameClear;
    SpriteRenderer sprite;

    void Start() {
        game = FindObjectOfType<PauseController>();
        gameOver = FindObjectOfType<GameOverController>();
        gameClear = FindObjectOfType<GameClearController>();
        sprite = GetComponent<SpriteRenderer>();
        audioSource = GetComponent<AudioSource>();
        rbody2D = GetComponent<Rigidbody2D>();
        hitBox = GetComponent<Collider2D>();

        leftAttack.gameObject.SetActive(false);
        rightAttack.gameObject.SetActive(false);

        direction = RIGHT;
        onFloor = true;
        isDead = false;
        doubleJumpsAvailable = 0;
        enemiesKilled = 0;
    }

    void Update() {
        if (!game.IsPaused() && !gameOver.isGameOver && !gameClear.isGameClear) {
            CheckKeys();
            UpdateDirection();
        }
    }

    private void FixedUpdate() {
        if (!game.IsPaused() && !gameOver.isGameOver && !gameClear.isGameClear) {
            DoFixedUpdate();
        }
    }

    private void DoFixedUpdate() {
        DoMovement();

        if (jump) {
            DoJump();
            jump = false;
        }

        ApplyFallSpeed();
    }

    private bool CanMove() {
        return !isAttacking;
    }

    private void DoMovement() {
        if (
            (moveLeft && moveRight && direction == LEFT) ||
            (moveLeft && !moveRight)
        ) {
            Move(LEFT);
        }
        else if (
          (moveLeft && moveRight && direction == RIGHT) ||
          (!moveLeft && moveRight)
        ) { 
            Move(RIGHT);
        }
    }

    private void Move(int direction) {
        this.direction = direction;
        transform.position = new Vector2(
            transform.position.x + (BASE_SPEED * Time.deltaTime * direction),
            transform.position.y);
    }

    private void DoJump() {
        rbody2D.velocity = Vector2.up * JUMP_VELOCITY;

        if (!onFloor) {
            doubleJumpsAvailable--;
            hasDoubleJumped = true;
        }
    }

    private void CheckKeys() {
        if (CanMove()) {
            moveLeft = Input.GetKey(KeyCode.LeftArrow);
            if (Input.GetKeyDown(KeyCode.LeftArrow)) {
                direction = LEFT;
            } 

            moveRight = Input.GetKey(KeyCode.RightArrow);
            if (Input.GetKeyDown(KeyCode.RightArrow)) {
                direction = RIGHT;
            } 

        } else {
            moveLeft = false;
            moveRight = false;
        }

        if (Input.GetKeyDown(KeyCode.A) && CanAttack()) {
            DoAttack();
        }

        if (Input.GetKeyDown(KeyCode.S) && CanJump()) {
            jump = true;
            hasDoubleJumped = false;
            jumpReleased = false;
        } else if(Input.GetKeyUp(KeyCode.S)) {
            jumpReleased = true;
        }
    }

    private bool CanJump() {
        return (!isAttacking) && (onFloor || (doubleJumpsAvailable > 0 && !hasDoubleJumped));
    }

    private bool CanAttack() {
        return onFloor;
    }

    private void DoAttack() {
        if (!isAttacking) {
            isAttacking = true;
            audioSource.PlayOneShot(swordAttack);
        } else {
            attackCombo = true;
        }
    }

    public void AttackFinished() {
        if (attackCombo) {
            attackCombo = false;
            isAttacking = true;
            audioSource.PlayOneShot(swordAttack);
        } else {
            isAttacking = false;
        }
    }

    private void ApplyFallSpeed() {
        // Double the gravity while falling or when releasing the jump button
        // this allows more control over the jumps, having longer and shorter ones
        if (
            rbody2D.velocity.y > 0.2f && jumpReleased || 
            rbody2D.velocity.y < 0.2f
        ) {
            rbody2D.velocity += Vector2.up * Physics2D.gravity * Time.deltaTime;
        }
    }

    private void UpdateDirection() {
        sprite.flipX = (direction == LEFT);
    }

    public void EnterFloor() {
        onFloor = true;
    }

    public void LeaveFloor() {
        onFloor = false;
    }

    public bool IsMoving() {
        return moveLeft || moveRight;
    }

    public void ActivateAttack() {
        if (direction == LEFT) {
            leftAttack.gameObject.SetActive(true);
        } else {
            rightAttack.gameObject.SetActive(true);
        }
    }

    public void DeactivateAttack() {
        leftAttack.gameObject.SetActive(false);
        rightAttack.gameObject.SetActive(false);
    }

    public void Die()
    {
        if (!isDead)
        {
            isDead = true;
            rbody2D.gravityScale = 0;
            rbody2D.velocity = new Vector2(0, 0);
            audioSource.PlayOneShot(deathSound);
            hitBox.enabled = false;
            gameOver.GameOver();
        }
    }

    public Collider2D GetHitBox()
    {
        return hitBox;
    }
}
