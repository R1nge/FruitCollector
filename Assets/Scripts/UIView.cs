using TMPro;
using UnityEngine;

public class UIView
{
    private readonly Canvas _mainMenu, _inGame, _gameOver;
    private readonly TextMeshProUGUI _scoreText, _highScoreText;

    public UIView(Canvas mainMenu, Canvas inGame, Canvas gameOver, TextMeshProUGUI scoreText, TextMeshProUGUI highScoreText)
    {
        _mainMenu = mainMenu;
        _inGame = inGame;
        _gameOver = gameOver;
        _scoreText = scoreText;
        _highScoreText = highScoreText;
    }

    public void OnGameLoaded()
    {
        _mainMenu.gameObject.SetActive(true);
        _inGame.gameObject.SetActive(false);
        _gameOver.gameObject.SetActive(false);
    }

    public void OnGameStarted()
    {
        _mainMenu.gameObject.SetActive(false);
        _inGame.gameObject.SetActive(true);
        _gameOver.gameObject.SetActive(false);
    }

    public void UpdateScore(ref int score)
    {
        _scoreText.text = score.ToString();
    }

    public void UpdateHighScore(ref int highScore)
    {
        _highScoreText.text = $"HighScore: {highScore}";
    }

    public void OnGameOver()
    {
        _mainMenu.gameObject.SetActive(false);
        _inGame.gameObject.SetActive(false);
        _gameOver.gameObject.SetActive(true);
    }
}