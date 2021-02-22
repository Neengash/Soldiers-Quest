using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameOverPanelController : MonoBehaviour
{

    int selectedOption;
    [SerializeField] Text selectedOptionText;
    GameOverController gameOverController;
    RectTransform selectedOptionPosition;
    const int RETRY_LEVEL = 0;
    const int EXIT_LEVEL = 1;

    const int LEVEL_SELECT_SCENE = 1;

    const float RETRY_LEVEL_Y = 3;
    const float EXIT_LEVEL_Y = -27;

    void Start()
    {
        gameOverController = FindObjectOfType<GameOverController>();
        selectedOptionPosition = selectedOptionText.GetComponent<RectTransform>();
        selectedOption = RETRY_LEVEL;
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
        float yPosition = (selectedOption == RETRY_LEVEL)
            ? RETRY_LEVEL_Y
            : EXIT_LEVEL_Y;

        selectedOptionPosition.anchoredPosition = new Vector2(
            selectedOptionPosition.anchoredPosition.x,
            yPosition);
    }

    private void SelectOption()
    {
        if (selectedOption == RETRY_LEVEL)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        } else {
            SceneManager.LoadScene(LEVEL_SELECT_SCENE);
        }
    }
}
