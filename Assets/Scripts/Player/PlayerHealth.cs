using UnityEngine;

namespace Player
{
    public class PlayerHealth : MonoBehaviour
    {
        [SerializeField] private float health;
        private GameManager _gameManager;

        private void Awake() => _gameManager = FindObjectOfType<GameManager>();

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