using System;
using UnityEngine;

public class ScoreHandler : MonoBehaviour
{
    private int _score, _highScore;

    public event Action<int, int> OnScoreChangedEvent;

    private void Awake() => _highScore = PlayerPrefs.GetInt("HighScore");

    private void Start() => OnScoreChangedEvent?.Invoke(_score, _highScore);

    public void AddScore(int amount)
    {
        _score += amount;
        if (_score >= _highScore)
        {
            _highScore = _score;
            PlayerPrefs.SetInt("HighScore", _highScore);
            PlayerPrefs.Save();
        }

        OnScoreChangedEvent?.Invoke(_score, _highScore);
    }
}