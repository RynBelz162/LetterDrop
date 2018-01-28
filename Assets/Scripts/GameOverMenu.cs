using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverMenu : MonoBehaviour
{
    public void MainMenu()
    {
        TimerScript.gameOver = false;
        SceneManager.LoadScene("Menu");
    }

    public void RestartGame()
    {
        TimerScript.gameOver = false;
        SceneManager.LoadScene("Game");
    }
}