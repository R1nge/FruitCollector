using UnityEngine;

public class Health : MonoBehaviour
{
    public float health;

    public void TakeDamage(float amount)
    {
        health -= amount;
        if (health <= 0)
        {
            Destroy(gameObject);
        }
    }
}