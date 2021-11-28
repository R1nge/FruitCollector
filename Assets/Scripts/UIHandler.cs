using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIHandler : MonoBehaviour
{
    [SerializeField] private Text scoreText, highScoreText;
    [SerializeField] private GameObject playScreen, gameOverScreen;

    private void Start()
    {
        Time.timeScale = 0;
        playScreen.SetActive(true);
        gameOverScreen.SetActive(false);
    }

    public void UpdateScoreUI(int score, int highScore)
    {
        scoreText.text = score.ToString();
        highScoreText.text = "HighScore: " + highScore;
    }

    public void StartGame()
    {
        Time.timeScale = 1;
        playScreen.SetActive(false);
    }

    public void GameOver()
    {
        Time.timeScale = 0;
        gameOverScreen.SetActive(true);
        highScoreText.enabled = true;
    }

    public void Restart()
    {
        SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().buildIndex);
    }
}