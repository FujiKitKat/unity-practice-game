using UnityEngine;
using UnityEngine.UI;

public class EnemyScript : MonoBehaviour
{
    // Reference to the player to detect and attack
    public PlayerMovement player;
    
    // Enemy health
    public int _health = 20;
    
    // Cooldown between attacks
    readonly float _attackCoolDown = 5f;
    private float _lastAttackTime = 0f;
    
    // Damage dealt to the player per attack
    public int damage = 7;
    
    // Distance at which the enemy starts attacking
    readonly float _distanceToPlayer = 5f;
    
    // UI slider showing enemy health
    public Slider SliderHealt;
    
    //Animation
    private Animator _animator;
    
    private void Start()
    {
        _animator = GetComponent<Animator>();
        // Find the player in the scene
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerMovement>();
        EnemyResurrection();
    }

    private void Update()
    {
        PlayerDetection();
    }

    public void TakeDamage(int damage)
    {
        // Reduce health and update UI
        _health -= damage;
          SliderHealt.value= _health;
        Debug.Log("Enemy HP is " + _health);
        _animator.SetTrigger("GetHit");
        if (_health <= 0)
        {
            _animator.SetTrigger("DieTrigger");
            // Destroy enemy after 5 seconds
            Destroy(gameObject, 5f);
            // Remove health slider UI
            Destroy(SliderHealt);
        }
        
    }

    private void PlayerDetection()
    {
        Vector3 position = transform.position;
        // If player is close enough and enemy is alive
        if (Vector3.Distance(position, player.transform.position) <= _distanceToPlayer && _health > 0)
        {
            // Face the player
            transform.LookAt(player.transform.position);
            // Attack if cooldown has passed
            if (Time.time - _lastAttackTime >= _attackCoolDown)
            {
                _animator.SetTrigger("Attack");
                Attack();
                _lastAttackTime = Time.time;
            }
        }
    }

    private void Attack()
    {
        if (player != null)
        {
            player.TakeDamagePlayer(damage);
        }
    }

    private void EnemyResurrection()
    {
        // Method for resurrection logic
        // Currently does nothing
        if (gameObject == null)
        {
            
        }
    }
}
