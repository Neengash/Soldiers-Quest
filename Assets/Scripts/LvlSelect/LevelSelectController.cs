using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelSelectController : MonoBehaviour
{
    [SerializeField] GameObject floors;
    [SerializeField] GameObject levels;

    [SerializeField] HintText mainMenu;
    [SerializeField] HintText noAdvance;

    [SerializeField] MeshRenderer blackLayer;
    const float FADE_BLACK = 0.01f;

    HeroController hero;
    ScoreController score;
    ParallaxController background;
    LvlScenes lvlScenes;

    float speed;
    const float LEFT_SPEED = 0.1f;
    const float RIGHT_SPEED = -0.1f;
    const float STOP = 0f;

    int currentLevel;
    const int MIN_LEVEL = 1;

    AudioSource audioSource;
    [SerializeField] AudioClip soundOK;
    [SerializeField] AudioClip soundNO;

    float backToMenuTimer;
    const float DOUBLE_CLICK_TIME = 2f;

    bool exit;

    void Start()
    {
        score = FindObjectOfType<ScoreController>();
        hero = FindObjectOfType<HeroController>();
        audioSource = GetComponent<AudioSource>();
        background = FindObjectOfType<ParallaxController>();
        lvlScenes = FindObjectOfType<LvlScenes>();

        blackLayer.material.color = new Color(0f, 0f, 0f, 0f);
        blackLayer.gameObject.SetActive(false);

        speed = RIGHT_SPEED;
        currentLevel = 1;
        exit = false;
        background.SetSpeed(0.05f);
    }

    void Update()
    {

        if (exit) {
            DoExitAnimation();
        } else if (speed != 0f) {
            DoAnimation();
        } else {
            CheckInput();
        }

        if (backToMenuTimer > 0f) {
            backToMenuTimer -= Time.deltaTime;
        }
    }

    public void Stop()
    {
        speed = STOP;
        hero.Stop();
        background.SetSpeed(0f);
    }

    private void RightMovement()
    {
        if (currentLevel != (score.GetMaxLvl() + 1) ) {
            speed = RIGHT_SPEED;
            hero.MoveRight();
            background.SetSpeed(0.05f);
            currentLevel++;
        } else {
            noAdvance.FadeIn();
            audioSource.PlayOneShot(soundNO);
        }
    }

    private void LeftMovement ()
    {
        if (currentLevel == MIN_LEVEL) {
            if (backToMenuTimer > 0f) {
                SceneManager.LoadScene(0);
            } else {
                mainMenu.FadeIn();
                backToMenuTimer = DOUBLE_CLICK_TIME;
            }
        } else {
            speed = LEFT_SPEED;
            hero.MoveLeft();
            background.SetSpeed(-0.05f);
            currentLevel--;
        }
    }

    private void Interact()
    {
        audioSource.PlayOneShot(soundOK);
        exit = true;
        blackLayer.gameObject.SetActive(true);
    }

    private void CheckInput()
    {
        if (Input.GetKeyUp(KeyCode.RightArrow)) {
            RightMovement();
        } else if (Input.GetKeyUp(KeyCode.LeftArrow)) {
            LeftMovement();
        } else if (Input.GetKeyUp(KeyCode.A)) {
            Interact();
        }
    }

    private void DoExitAnimation()
    {
        float a = blackLayer.material.color.a;
        a += FADE_BLACK;
        if (a > 1) {
            int scene = lvlScenes.GetLevelScene(currentLevel);
            SceneManager.LoadScene(scene);
        }
        blackLayer.material.color = new Color(0f, 0f, 0f, a);
    }

    void DoAnimation()
    {
        floors.transform.position = new Vector2(
            floors.transform.position.x + speed,
            floors.transform.position.y);

        levels.transform.position = new Vector2(
            levels.transform.position.x + speed,
            levels.transform.position.y);
    }
}
