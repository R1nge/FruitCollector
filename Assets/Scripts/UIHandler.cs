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
        _scoreHandler.OnHighScoreChangedEvent += UpdateHighScoreUI;
    }

    private void Start()
    {
        _gameManager.SetTimeScale(0);
        mainMenu.gameObject.SetActive(true);
        inGame.gameObject.SetActive(false);
        gameOver.gameObject.SetActive(false);
    }

    private void UpdateScoreUI(int score) => scoreText.text = score.ToString();

    private void UpdateHighScoreUI(int highScore) => highScoreText.text = $"HighScore: {highScore}";

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

    private void OnDestroy()
    {
        _gameManager.OnStartGameEvent -= StartGame;
        _gameManager.OnGameOverEvent -= GameOver;
        _scoreHandler.OnScoreChangedEvent -= UpdateScoreUI;
        _scoreHandler.OnHighScoreChangedEvent -= UpdateHighScoreUI;
    }
}