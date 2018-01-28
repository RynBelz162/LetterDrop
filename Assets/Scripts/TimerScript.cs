using UnityEngine;
using UnityEngine.UI;

public class TimerScript : MonoBehaviour
{
    public static bool gameOver = false;
    private System.TimeSpan timeLeft = new System.TimeSpan(0, 0, 5);
    private Text timerTextBox;
    private GameObject gameOverMenuUI;

    // Use this for initialization
    void Start()
    {
        gameOverMenuUI = GameObject.Find("Panel");
        gameOverMenuUI.SetActive(false);
        DisplayTime();
        InvokeRepeating("DisplayTime", 1.0f, 1.0f);
    }

    void DisplayTime()
    {
        if (timeLeft.Equals(System.TimeSpan.Zero))
        {
            GameOver();
        }

        timerTextBox = GameObject.Find("Timer").GetComponent<Text>();
        timerTextBox.transform.position = new Vector3(CameraScript.minX * (-.6f), CameraScript.maxY, 0);
        timerTextBox.text = new System.DateTime(timeLeft.Ticks).ToString("mm:ss");
        ClockTick();
    }

    void ClockTick()
    {
        timeLeft = timeLeft.Subtract(System.TimeSpan.FromSeconds(1));
    }

    void GameOver()
    {
        //set the flag for other scripts
        gameOver = true;

        //freeze the letters
        FreezeFallingLetters();

        //activate game over menu
        gameOverMenuUI.SetActive(true);

        //cancel the timer countdown
        CancelInvoke();
    }

    void FreezeFallingLetters()
    {
        //freeze the failing letters
        foreach (var letter in WordSpawnerScript.spawnedLetters)
        {
            letter.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezeAll;
        }
        WordSpawnerScript.spawnedLetters = new L <>
    }
}
