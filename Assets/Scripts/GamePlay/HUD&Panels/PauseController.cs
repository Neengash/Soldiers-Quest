using UnityEngine;

public class PauseController : MonoBehaviour
{
    bool pause;
    float timeScale;

    [SerializeField] PausePanelController pausePanel;
    GameOverController gameOver;
    GameClearController gameClear;

    void Start()
    {
        pause = false;
        timeScale = Time.timeScale;
        gameOver = FindObjectOfType<GameOverController>();
        gameClear = FindObjectOfType<GameClearController>();
    }

    private void Update()
    {
        if (!gameOver.isGameOver && !gameClear.isGameClear) {
            CheckGamePause();
        }
    }
    private void CheckGamePause()
    {
        if (Input.GetKeyDown(KeyCode.Escape)) {
            if (IsPaused()) {
                ResumeGame();
            } else {
                PauseGame();
            }
        }
    }

    public bool IsPaused() {
        return pause;
    }

    public void PauseGame() {
        pause = true;
        Time.timeScale = 0;
        pausePanel.gameObject.SetActive(true);
    }

    public void ResumeGame()
    {
        if (!gameOver.isGameOver) {
            pause = false;
            Time.timeScale = timeScale;
            pausePanel.gameObject.SetActive(false);
        }
    }
}
