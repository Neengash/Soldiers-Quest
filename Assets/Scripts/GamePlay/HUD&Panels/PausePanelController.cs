using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PausePanelController : MonoBehaviour
{
    int selectedOption;
    [SerializeField] Text selectedOptionText;
    PauseController pauseController;
    RectTransform selectedOptionPosition;
    const int RESUME_GAME = 0;
    const int EXIT_LEVEL = 1;

    const int LEVEL_SELECT_SCENE = 1;

    const float RESUME_GAME_Y = 3;
    const float EXIT_LEVEL_Y = -27;

    void Start()
    {
        pauseController = FindObjectOfType<PauseController>();
        selectedOptionPosition = selectedOptionText.GetComponent<RectTransform>();
        selectedOption = RESUME_GAME;
        UpdateSelectedOption();
    }

    void Update()
    {
        if (
            Input.GetKeyDown(KeyCode.DownArrow) || 
            Input.GetKeyDown(KeyCode.UpArrow)
        ) {
            selectedOption++;
            selectedOption %= 2;
            UpdateSelectedOption();
        }

        if (Input.GetKeyDown(KeyCode.A))
        {
            SelectOption();
        }
    }

    private void UpdateSelectedOption()
    {
        float yPosition = (selectedOption == RESUME_GAME)
            ? RESUME_GAME_Y
            : EXIT_LEVEL_Y;

        selectedOptionPosition.anchoredPosition = new Vector2(
            selectedOptionPosition.anchoredPosition.x,
            yPosition);
    }

    private void SelectOption()
    {
        pauseController.ResumeGame();
        if (selectedOption == RESUME_GAME)
        {
            this.gameObject.SetActive(false);
        } else {
            SceneManager.LoadScene(LEVEL_SELECT_SCENE);
        }
    }
}
