using UnityEngine;

namespace Collectables
{
    public abstract class Collectable : MonoBehaviour
    {
        protected abstract void PickUp();

        private void OnCollisionEnter2D(Collision2D other)
        {
            if (other.transform.CompareTag("Player"))
            {
                PickUp();
            }
        }
    }
}