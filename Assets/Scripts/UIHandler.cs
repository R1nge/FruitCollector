using TMPro;
using UnityEngine;
using VContainer;

public class UIHandler : MonoBehaviour
{
    [SerializeField] private Canvas mainMenu, inGame, gameOver;
    [SerializeField] private TextMeshProUGUI scoreText, highScoreText;
    private GameManager _gameManager;
    private ScoreHandler _scoreHandler;

    [Inject]
    private void Construct(GameManager gameManager, ScoreHandler scoreHandler)
    {
        _gameManager = gameManager;
        _scoreHandler = scoreHandler;
    }

    private void Awake()
    {
        _gameManager.OnStartGameEvent += OnGameStarted;
        _gameManager.OnGameOverEvent += OnGameOver;
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

    public void StartGame() => _gameManager.StartGame();

    public void RestartGame() => _gameManager.Restart();

    private void UpdateScoreUI(int score) => scoreText.text = score.ToString();

    private void UpdateHighScoreUI(int highScore) => highScoreText.text = $"HighScore: {highScore}";

    private void OnGameStarted()
    {
        _gameManager.SetTimeScale(1);
        mainMenu.gameObject.SetActive(false);
        inGame.gameObject.SetActive(true);
        gameOver.gameObject.SetActive(false);
    }

    private void OnGameOver()
    {
        _gameManager.SetTimeScale(0);
        mainMenu.gameObject.SetActive(false);
        inGame.gameObject.SetActive(false);
        gameOver.gameObject.SetActive(true);
    }

    private void OnDestroy()
    {
        _gameManager.OnStartGameEvent -= StartGame;
        _gameManager.OnGameOverEvent -= OnGameOver;
        _scoreHandler.OnScoreChangedEvent -= UpdateScoreUI;
        _scoreHandler.OnHighScoreChangedEvent -= UpdateHighScoreUI;
    }
}