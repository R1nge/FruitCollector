using System;
using UnityEngine;
using VContainer.Unity;

public class ScoreHandler : IStartable
{
    private int _score, _highScore;
    public event Action<int> OnScoreChangedEvent;
    public event Action<int> OnHighScoreChangedEvent;

    public void Start()
    {
        _highScore = PlayerPrefs.GetInt("HighScore");
        OnScoreChangedEvent?.Invoke(_score);
        OnHighScoreChangedEvent?.Invoke(_highScore);
    }

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