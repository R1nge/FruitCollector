using UnityEngine;

namespace MovementInput
{
    public class MouseMovementInput : MonoBehaviour, IMovementInputGetter
    {
        public float Horizontal { get; private set; }
        public float Vertical { get; private set; }

        private Camera _camera;

        private void Awake() => _camera = FindObjectOfType<Camera>();

        private void Update() => GetInput();

        private void GetInput()
        {
            Vector3 screenPosMouse =
                new Vector3(Input.mousePosition.x, Input.mousePosition.y, 10);
            Vector3 worldPosMouse = _camera.ScreenToWorldPoint(screenPosMouse);
            Horizontal = worldPosMouse.x;
            Vertical = worldPosMouse.y;
        }
    }
}