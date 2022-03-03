using Player;
using UnityEngine;

namespace Enemies
{
    public abstract class Enemy : MonoBehaviour
    {
        public float damage;

        private void OnCollisionEnter2D(Collision2D other)
        {
            if (other.transform.TryGetComponent(out PlayerHealth health))
            {
                health.TakeDamage(damage);
            }
        }
    }
}