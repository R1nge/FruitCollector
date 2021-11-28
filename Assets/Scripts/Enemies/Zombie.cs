using System;
using UnityEngine;
using Random = UnityEngine.Random;

public class Zombie : Enemy
{
    private float moveX, moveY;

    private void Start()
    {
        PickPosition();
        print("Pick");
    }

    private void Update()
    {
        Move();
    }

    public override void Move()
    {
        if (transform.position != new Vector3(moveX, moveY, transform.position.z))
        {
            transform.position = Vector3.MoveTowards(
                transform.position,
                new Vector3(moveX, moveY),
                Time.deltaTime * speed);
        }
        else
        {
            PickPosition();
        }
    }

    private void PickPosition()
    {
        moveY = Random.Range
        (Camera.main.ScreenToWorldPoint(new Vector2(0, 0)).y,
            Camera.main.ScreenToWorldPoint(new Vector2(0, Screen.height)).y);
        moveX = Random.Range
        (Camera.main.ScreenToWorldPoint(new Vector2(0, 0)).x,
            Camera.main.ScreenToWorldPoint(new Vector2(Screen.width, 0)).x);
    }
}