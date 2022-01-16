using UnityEngine;
public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float speed;
    private PlayerInput _playerInput;
    private Vector2 _touchPos;

    private void Awake()
    {
        _playerInput = GetComponent<PlayerInput>();
        _playerInput.OnTouchedEvent += Move;
    }

    private void Move(Vector2 position)
    {
        _touchPos = position;
    }

    private void Update()
    {
        transform.position = Vector3.MoveTowards(
            transform.position,
            new Vector3(_touchPos.x, _touchPos.y, 0),
            Time.deltaTime * speed);
    }

    private void OnDestroy ()
    {
        _playerInput.OnTouchedEvent -= Move;
    }
}