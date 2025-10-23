using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    // Reference to the PlayerHealth script to manage health
    public PlayerHealth PlayerHealth;

    void Start()
    {
        PlayerHealth = GetComponent<PlayerHealth>();
        
    }
    
    // Method to apply damage to the player
    public void TakeDamagePlayer(int damage)
    {
        PlayerHealth.TakeDamage(damage);
    }

    // Method to heal the player
    public void TakeHealthPlayer(int health)
    {
        PlayerHealth.TakeHealth(health);
    }
    
}
