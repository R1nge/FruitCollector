using TMPro;
using UnityEngine;

public class UIHandler : MonoBehaviour
{
    [SerializeField] private Canvas mainMenu, inGame, gameOver;
    [SerializeField] private TextMeshProUGUI scoreText, highScoreText;
    private GameManager _gameManager;
    private ScoreHandler _scoreHandler;

    private void Awake()
    {
        _gameManager = FindObjectOfType<GameManager>();
        _gameManager.OnStartGameEvent += StartGame;
        _gameManager.OnGameOverEvent += GameOver;
        _scoreHandler = FindObjectOfType<ScoreHandler>();
        _scoreHandler.OnScoreChangedEvent += UpdateScoreUI;
    }

    private void Start()
    {
        _gameManager.SetTimeScale(0);
        mainMenu.gameObject.SetActive(true);
        inGame.gameObject.SetActive(false);
        gameOver.gameObject.SetActive(false);
    }

    private void UpdateScoreUI(int score, int highScore)
    {
        scoreText.text = score.ToString();
        highScoreText.text = "HighScore: " + highScore;
    }

    private void StartGame()
    {
        _gameManager.SetTimeScale(1);
        mainMenu.gameObject.SetActive(false);
        inGame.gameObject.SetActive(true);
        gameOver.gameObject.SetActive(false);
    }

    private void GameOver()
    {
        _gameManager.SetTimeScale(0);
        mainMenu.gameObject.SetActive(false);
        inGame.gameObject.SetActive(false);
        gameOver.gameObject.SetActive(true);
    }

    private void OnDestroy() => _scoreHandler.OnScoreChangedEvent += UpdateScoreUI;
}