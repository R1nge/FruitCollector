using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager
{
    public event Action OnStartGameEvent;
    public event Action OnGameOverEvent;

    public void StartGame() => OnStartGameEvent?.Invoke();
    public void GameOver() => OnGameOverEvent?.Invoke();
    public void Restart() => SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    public void SetTimeScale(int value) => Time.timeScale = value;
}