using UnityEngine;
using UnityEngine.SceneManagement;

public class Scene : MonoBehaviour
{
    // 1 - change @ inspector!
    public GameObject gameOverLose;
    public GameObject gameOverWin;
    bool isGameOver = false;

    public void GameOver(bool isRoundLost)
    {
        if (isGameOver) return;
        isGameOver = true;
        Time.timeScale = 0f; // pause time

        if (isRoundLost){ gameOverLose.SetActive(true); } // win-lose condition
        else { gameOverWin.SetActive(true); }
    }

    public void RestartGame()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        gameOverLose.SetActive(false);
        gameOverWin.SetActive(false);
    }

    public void QuitGame()
    {
        Time.timeScale = 1f;
        Application.Quit();
    }
}
