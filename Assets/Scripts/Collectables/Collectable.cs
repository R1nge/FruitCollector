using System;
using UnityEngine;

public abstract class Collectable : MonoBehaviour
{
    public abstract void PickUp();

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.transform.CompareTag("Player"))
        {
            PickUp();
        }
    }
}