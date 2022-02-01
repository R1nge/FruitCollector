using UnityEngine;

namespace Player
{
    public class MouseMovementInput : MonoBehaviour, IMovementInputGetter
    {
        private Camera _camera;
        public float Horizontal { get; private set; }
        public float Vertical { get; private set; }

        private void Awake()
        {
            _camera = FindObjectOfType<Camera>();
        }

        private void Update()
        {
            GetInput();
        }

        private void GetInput()
        {
            Vector3 screenPosMouse = new Vector3(Input.mousePosition.x, Input.mousePosition.y, 10);
            Vector3 worldPosMouse = _camera.ScreenToWorldPoint(screenPosMouse);
            Horizontal = worldPosMouse.x;
            Vertical = worldPosMouse.y;
        }
    }
}