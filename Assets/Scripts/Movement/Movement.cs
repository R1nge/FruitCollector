using MovementInput;
using UnityEngine;

namespace Movement
{
    public class Movement : MonoBehaviour
    {
        [SerializeField] private float speed;
        private IMovementInputGetter _movementInputGetter;

        private void Awake() => _movementInputGetter = GetComponent<IMovementInputGetter>();

        private void Update()
        {
            transform.position = Vector3.MoveTowards(
                transform.position,
                new(_movementInputGetter.Horizontal, _movementInputGetter.Vertical, 0),
                Time.deltaTime * speed);
        }
    }
}