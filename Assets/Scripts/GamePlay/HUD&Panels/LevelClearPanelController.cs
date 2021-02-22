using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelClearPanelController : MonoBehaviour
{

    int selectedOption;
    [SerializeField] Text selectedOptionText;
    RectTransform selectedOptionPosition;

    const int NEXT_LEVEL = 0;
    const int LEVEL_SELECT = 1;

    const int LEVEL_SELECT_SCENE = 1;

    const float NEXT_LEVEL_Y = 3;
    const float LEVEL_SELECT_Y = -27;

    void Start()
    {
        selectedOptionPosition = selectedOptionText.GetComponent<RectTransform>();
        selectedOption = NEXT_LEVEL;
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
        float yPosition = (selectedOption == NEXT_LEVEL)
            ? NEXT_LEVEL_Y
            : LEVEL_SELECT_Y;

        selectedOptionPosition.anchoredPosition = new Vector2(
            selectedOptionPosition.anchoredPosition.x,
            yPosition);
    }

    private void SelectOption()
    {
        if (selectedOption == NEXT_LEVEL)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        } else {
            SceneManager.LoadScene(LEVEL_SELECT_SCENE);
        }
    }
}
