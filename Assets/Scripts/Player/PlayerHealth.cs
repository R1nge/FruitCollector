using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public float health;
    private UIHandler _uiHandler;

    private void Awake()
    {
        _uiHandler = FindObjectOfType<UIHandler>();
    }

    public void TakeDamage(float amount)
    {
        health -= amount;
        if (health <= 0)
        {
            _uiHandler.GameOver();
            Destroy(gameObject);
        }
    }
}