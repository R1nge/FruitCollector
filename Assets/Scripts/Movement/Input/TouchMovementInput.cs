using UnityEngine;

namespace Player
{
    public class TouchMovementInput : MonoBehaviour, IMovementInputGetter
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
            if (Input.touchCount > 0)
            {
                Touch touch = Input.GetTouch(0);
                Vector3 screenPos = new Vector3(touch.position.x, touch.position.y, 10);
                Vector3 worldPos = _camera.ScreenToWorldPoint(screenPos);
                Horizontal = worldPos.x;
                Vertical = worldPos.y;
            }
        }
    }
}