using UnityEngine;

public class HpItemScript : MonoBehaviour
{
    public int Hp = 5;
    public PlayerMovement player;

    private void Start()
    {
        player = FindObjectOfType<PlayerMovement>();
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && player.PlayerHealth.playerHealth < 30)
        {
            player.TakeHealthPlayer(Hp);
            Destroy(gameObject);
        }
    }
}
