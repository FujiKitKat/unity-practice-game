using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public PlayerHealth PlayerHealth;

    void Start()
    {
        PlayerHealth = GetComponent<PlayerHealth>();
        
    }
    
    public void TakeDamagePlayer(int damage)
    {
        PlayerHealth.TakeDamage(damage);
    }

    public void TakeHealthPlayer(int health)
    {
        PlayerHealth.TakeHealth(health);
    }
    
}
