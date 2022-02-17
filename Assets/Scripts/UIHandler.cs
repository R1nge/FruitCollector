using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIHandler : MonoBehaviour
{
    [SerializeField] private Canvas mainMenu, inGame, gameOver;
    [SerializeField] private TextMeshProUGUI scoreText, highScoreText;

    private void Start()
    {
        Time.timeScale = 0;
        mainMenu.gameObject.SetActive(true);
        inGame.gameObject.SetActive(false);
        gameOver.gameObject.SetActive(false);
    }

    public void UpdateScoreUI(int score, int highScore)
    {
        scoreText.text = score.ToString();
        highScoreText.text = "HighScore: " + highScore;
    }

    public void StartGame()
    {
        Time.timeScale = 1;
        mainMenu.gameObject.SetActive(false);
        inGame.gameObject.SetActive(true);
        gameOver.gameObject.SetActive(false);
    }

    public void GameOver()
    {
        Time.timeScale = 0;
        mainMenu.gameObject.SetActive(false);
        inGame.gameObject.SetActive(false);
        gameOver.gameObject.SetActive(true);
    }

    public void Restart()
    {
        SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().buildIndex);
    }
}