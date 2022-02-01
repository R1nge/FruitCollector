using System;
using UnityEngine;
using Random = UnityEngine.Random;

public class RandomMovementInput : MonoBehaviour, IMovementInputGetter
{
    public float Horizontal { get; private set; }
    public float Vertical { get; private set; }

    private Camera _camera;

    private void Awake()
    {
        _camera = FindObjectOfType<Camera>();
    }

    private void Start()
    {
        PickPosition();
    }

    private void Update()
    {
        if (transform.position != new Vector3(Horizontal, Vertical, transform.position.z)) return;

        PickPosition();
    }

    private void PickPosition()
    {
        Horizontal = Random.Range
        (_camera.ScreenToWorldPoint(new Vector2(0, 0)).x,
            _camera.ScreenToWorldPoint(new Vector2(Screen.width, 0)).x);
        Vertical = Random.Range
        (_camera.ScreenToWorldPoint(new Vector2(0, 0)).y,
            _camera.ScreenToWorldPoint(new Vector2(0, Screen.height)).y);
    }
}