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

        if (isRoundLost) // win-lose condition
        { 
            gameOverLose.SetActive(true); 
            gameOverLose.GetComponent<AudioSource>().Play();
        } 
        else 
        { 
            gameOverWin.SetActive(true);
            gameOverWin.GetComponent<AudioSource>().Play();
        }
    }

    public void RestartGame()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(1);
        gameOverLose.SetActive(false);
        gameOverWin.SetActive(false);
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
