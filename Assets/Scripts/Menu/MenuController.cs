using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class MenuController : MonoBehaviour
{
    ScoreController scoreController;

    ParallaxController backGround; 
    [SerializeField] GameObject floor;
    [SerializeField] GameObject menuTexts;
    [SerializeField] GameObject controlls;
    [SerializeField] Animator hero;

    [SerializeField] TextMeshPro continueOption;
    [SerializeField] TextMeshPro selection;

    AudioSource audioSource;
    [SerializeField] AudioClip soundOK;
    [SerializeField] AudioClip soundNO;

    int selectedOption;
    const float Y_COORDINATE_SELECTED_CONTINUE = 1.5f;
    const float Y_COORDINATE_SELECTED_NEWGAME = 0.5f;
    const int SELECTED_CONTINUE = 1;
    const int SELECTED_NEWGAME = 2;

    bool continueAvailable;
    bool animationRunning;
    float speed = 0.1f;

    void Start()
    {
        backGround = FindObjectOfType<ParallaxController>();
        animationRunning = false;
        audioSource = GetComponent<AudioSource>();
        scoreController = FindObjectOfType<ScoreController>();

        if (scoreController.HasSavedGame())
        {
            continueAvailable = true;
            selectedOption = SELECTED_CONTINUE;
        } else
        {
            continueAvailable = false;
            selectedOption = SELECTED_NEWGAME;
            DisableContinueOption();
        }
        backGround.SetSpeed(0);

        UpdateSelection();
    }

    void Update()
    {
        if (animationRunning) {
            ResolveAnimation();
        } else {
            CheckInputs();
        }
    }
    void CheckInputs() {
        if (Input.GetKeyUp(KeyCode.A)) {
            OkPressed();
        } else if (
            (Input.GetKeyUp(KeyCode.UpArrow)) ||
            (Input.GetKeyUp(KeyCode.DownArrow))
        ) {
            selectedOption = (selectedOption == SELECTED_CONTINUE)
                ? SELECTED_NEWGAME
                : SELECTED_CONTINUE;

            UpdateSelection();
        }
    }

    void DisableContinueOption()
    {
        continueOption.color = new Color(0.2f, 0.2f, 0.2f);
    }

    void UpdateSelection()
    {
        float yValue = (selectedOption == SELECTED_CONTINUE)
            ? Y_COORDINATE_SELECTED_CONTINUE
            : Y_COORDINATE_SELECTED_NEWGAME;

        selection.transform.position = 
            new Vector2(selection.transform.position.x, yValue);
    }

    void OkPressed()
    {
        if (selectedOption == SELECTED_NEWGAME)
        {
            scoreController.ResetGame();
            ToNextScene();
        } else {
            if (continueAvailable) {
                ToNextScene();
            } else {
                audioSource.PlayOneShot(soundNO);
            }
        }
    }

    void ToNextScene()
    {
        audioSource.PlayOneShot(soundOK);
        animationRunning = true;
        backGround.SetSpeed(speed / 2);
        hero.SetBool("walk", true);
    }

    void ResolveAnimation()
    {
        floor.transform.position = new Vector2(
                floor.transform.position.x - speed, 
                floor.transform.position.y);

        menuTexts.transform.position = new Vector2(
                menuTexts.transform.position.x - speed, 
                menuTexts.transform.position.y);

        controlls.transform.position = new Vector2(
                controlls.transform.position.x - speed, 
                controlls.transform.position.y);
    }
}
