using System;
using UnityEngine;

namespace Collectables
{
    public abstract class Collectable : MonoBehaviour
    {
        public event Action<Collectable> OnPickedUpEvent;

        protected virtual void PickUp() => OnPickedUpEvent?.Invoke(this);

        private void OnCollisionEnter2D(Collision2D other)
        {
            if (other.transform.CompareTag("Player"))
            {
                PickUp();
            }
        }
    }
}