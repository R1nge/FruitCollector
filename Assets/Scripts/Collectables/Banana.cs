using UnityEngine;

public class Banana : Collectable
{
    [SerializeField] private int point;
    private ScoreHandler _scoreHandler;

    private void Awake() => _scoreHandler = FindObjectOfType<ScoreHandler>();

    protected override void PickUp()
    {
        _scoreHandler.AddScore(point);
        Destroy(gameObject);
    }
}