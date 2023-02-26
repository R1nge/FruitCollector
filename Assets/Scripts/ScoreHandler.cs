using System;
using UnityEngine;

public class ScoreHandler : MonoBehaviour
{
    private int _score, _highScore;
    
    public event Action<int> OnScoreChangedEvent;

    public event Action<int> OnHighScoreChangedEvent;

    private void Awake() => _highScore = PlayerPrefs.GetInt("HighScore");

    private void Start() => OnScoreChangedEvent?.Invoke(_score);

    public void AddScore(int amount)
    {
        _score += amount;
        if (_score >= _highScore)
        {
            _highScore = _score;
            OnHighScoreChangedEvent?.Invoke(_highScore);
            PlayerPrefs.SetInt("HighScore", _highScore);
            PlayerPrefs.Save();
        }

        OnScoreChangedEvent?.Invoke(_score);
    }
}