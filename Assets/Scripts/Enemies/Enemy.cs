using UnityEngine;

public abstract class Enemy : MonoBehaviour
{
    public float damage;
    public float speed;
    public abstract void Move();

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.transform.TryGetComponent(out PlayerHealth health))
        {
            health.TakeDamage(damage);
        }
    }
}