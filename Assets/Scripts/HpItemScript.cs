using UnityEngine;

public class HpItemScript : Character
{
    // Amount of health restored when picked up
    public int Hp = 5;
    // Reference to the player object
    public PlayerMovement player;

    private void Start()
    {
        player = FindObjectOfType<PlayerMovement>();
    }

    public void OnTriggerEnter(Collider other)
    {
        // If the player touches the HP item and their health is not full
        if (other.CompareTag("Player") && player.PlayerHealth.CurrentHealth < 30)
        {
            // Restore player's health and remove the item from the scene
            player.TakeHealthPlayer(Hp);
            Destroy(gameObject);
        }
    }
}
