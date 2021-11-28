using UnityEngine;

public class ScoreHandler : MonoBehaviour
{
    private int _score, _highScore;
    private UIHandler _uiHandler;

    private void Awake()
    {
        _uiHandler = GetComponent<UIHandler>();
        _highScore = PlayerPrefs.GetInt("HighScore");
    }

    private void Start()
    {
        _uiHandler.UpdateScoreUI(_score, _highScore);
    }

    public void AddScore(int amount)
    {
        _score += amount;
        if (_score >= _highScore)
        {
            _highScore = _score;
            PlayerPrefs.SetInt("HighScore", _highScore);
            PlayerPrefs.Save();
        }

        _uiHandler.UpdateScoreUI(_score, _highScore);
    }
}