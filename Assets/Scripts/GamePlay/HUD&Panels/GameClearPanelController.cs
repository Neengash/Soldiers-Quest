using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameClearPanelController : MonoBehaviour
{

    int selectedOption;
    [SerializeField] Text selectedOptionText;
    RectTransform selectedOptionPosition;
    GameClearController gameClearController;

    const int LEVEL_SELECT = 0;
    const int LEVEL_SELECT_SCENE = 1;
    const float NEXT_LEVEL_Y = 3;

    void Start()
    {
        gameClearController = FindObjectOfType<GameClearController>();
        selectedOptionPosition = selectedOptionText.GetComponent<RectTransform>();
        selectedOption = LEVEL_SELECT;
        UpdateSelectedOption();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            SelectOption();
        }
    }

    private void UpdateSelectedOption()
    {
        float yPosition = NEXT_LEVEL_Y;

        selectedOptionPosition.anchoredPosition = new Vector2(
            selectedOptionPosition.anchoredPosition.x,
            yPosition);
    }

    private void SelectOption()
    {
        SceneManager.LoadScene(LEVEL_SELECT_SCENE);
    }
}
