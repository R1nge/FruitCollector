using UnityEngine;
using VContainer;

namespace Player
{
    public class PlayerHealth : MonoBehaviour
    {
        [SerializeField] private float health;
        private GameManager _gameManager;

        [Inject]
        private void Construct(GameManager gameManager)
        {
            _gameManager = gameManager;
        }

        public void TakeDamage(float amount)
        {
            health -= amount;
            if (health <= 0)
            {
                _gameManager.GameOver();
                Destroy(gameObject);
            }
        }
    }
}