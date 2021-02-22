using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOverController : MonoBehaviour
{
    public bool isGameOver;

    [SerializeField] GameOverPanelController gameOverPanel;

    void Start()
    {
        isGameOver = false;
    }

    public void GameOver()
    {
        isGameOver = true;
        StartCoroutine(ActivateGameOverPanel());
    }

    IEnumerator ActivateGameOverPanel()
    {
        yield return new WaitForSeconds(1.5f);
        gameOverPanel.gameObject.SetActive(true);
    }
}
