using UnityEngine;

public class WeaponSwordScript : MonoBehaviour
{
    // Amount of damage this sword deals
    public int swordDamage = 10;
    private void OnTriggerEnter(Collider other)
    {
        // Check if the collided object is an enemy
        if (other.gameObject.CompareTag("EnemyTag"))
        {
            EnemyScript enemy = other.GetComponent<EnemyScript>();
            
            if (enemy != null)
            {
                enemy.TakeDamage(swordDamage);
            }
        }
    }
}
