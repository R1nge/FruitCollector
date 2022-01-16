using UnityEngine;
public class Zombie : Enemy
{
    private float _moveX, _moveY;

    private void Start()
    {
        PickPosition();
    }

    private void Update()
    {
        Move();
    }

    public override void Move()
    {
        if (transform.position != new Vector3(_moveX, _moveY, transform.position.z))
        {
            transform.position = Vector3.MoveTowards(
                transform.position,
                new Vector3(_moveX, _moveY),
                Time.deltaTime * speed);
        }
        else
        {
            PickPosition();
        }
    }

    private void PickPosition()
    {
        _moveX = Random.Range
            (Camera.main.ScreenToWorldPoint(new Vector2(0, 0)).x,
            Camera.main.ScreenToWorldPoint(new Vector2(Screen.width, 0)).x);
        _moveY = Random.Range
        (Camera.main.ScreenToWorldPoint(new Vector2(0, 0)).y,
            Camera.main.ScreenToWorldPoint(new Vector2(0, Screen.height)).y);
    }
}