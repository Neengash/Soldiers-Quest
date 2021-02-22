using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameClearController : MonoBehaviour
{
    public bool isGameClear;

    [SerializeField] GameObject gameClearPanel;

    ScoreController score;
    LvlScenes lvlScenes;

    float timeScale;

    void Start()
    {
        score = FindObjectOfType<ScoreController>();
        lvlScenes = FindObjectOfType<LvlScenes>();

        isGameClear = false;
        timeScale = Time.timeScale;
    }

    public void GameClear()
    {
        Time.timeScale = 0;
        isGameClear = true;
        gameClearPanel.gameObject.SetActive(true);

        if (lvlScenes.GetCurrentLevel() > score.GetMaxLvl()) {
            score.IncrementMaxLvl();
        }
    }

    private void OnDestroy()
    {
        Time.timeScale = timeScale;
    }
}
