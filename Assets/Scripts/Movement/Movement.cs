using UnityEngine;

public class Movement : MonoBehaviour
{
    [SerializeField] private float speed;
    private IMovementInputGetter movementInputGetter;

    private void Awake()
    {
        movementInputGetter = GetComponent<IMovementInputGetter>();
    }

    private void Update()
    {
        transform.position = Vector3.MoveTowards(
            transform.position,
            new Vector3(movementInputGetter.Horizontal, movementInputGetter.Vertical, 0),
            Time.deltaTime * speed);
    }
}