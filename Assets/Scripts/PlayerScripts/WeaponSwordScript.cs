using UnityEngine;

public class WeaponSwordScript : MonoBehaviour
{
    public int swordDamage = 10;
    private void OnTriggerEnter(Collider other)
    {
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
