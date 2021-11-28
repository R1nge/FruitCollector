using System;
using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    public event Action<Vector2> OnTouchedEvent;
    private Camera _camera;

    private void Awake()
    {
        _camera = FindObjectOfType<Camera>();
    }

    private void Update()
    {
        GetTouchInput();
    }

    private void GetTouchInput()
    {
#if UNITY_EDITOR
        Vector3 screenPosMouse = new Vector3(Input.mousePosition.x, Input.mousePosition.y, 10);
        Vector3 worldPosMouse = _camera.ScreenToWorldPoint(screenPosMouse);
        OnTouchedEvent?.Invoke(worldPosMouse);
#endif
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            Vector3 screenPos = new Vector3(touch.position.x, touch.position.y, 10);
            Vector3 worldPos = _camera.ScreenToWorldPoint(screenPos);
            OnTouchedEvent?.Invoke(worldPos);
        }
    }
}