using UnityEngine;
using VContainer;

public class UIController : MonoBehaviour
{
    [SerializeField] private UIModel uiModel;
    private UIView _view;
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
        _view = new(uiModel.mainMenu, uiModel.inGame, uiModel.gameOver, uiModel.scoreText, uiModel.highScoreText);
    }

    private void Start()
    {
        _view.OnGameLoaded();
        _gameManager.SetTimeScale(0);
    }

    public void StartGame() => _gameManager.StartGame();

    public void RestartGame() => _gameManager.Restart();

    private void UpdateScoreUI(int score) => _view.UpdateScore(ref score);

    private void UpdateHighScoreUI(int highScore)
    {
        _view.UpdateHighScore(ref highScore);
    }

    private void OnGameStarted()
    {
        _view.OnGameStarted();
        _gameManager.SetTimeScale(1);
    }

    private void OnGameOver()
    {
        _gameManager.SetTimeScale(0);
        _view.OnGameOver();
    }

    private void OnDestroy()
    {
        _gameManager.OnStartGameEvent -= StartGame;
        _gameManager.OnGameOverEvent -= OnGameOver;
        _scoreHandler.OnScoreChangedEvent -= UpdateScoreUI;
        _scoreHandler.OnHighScoreChangedEvent -= UpdateHighScoreUI;
    }
}