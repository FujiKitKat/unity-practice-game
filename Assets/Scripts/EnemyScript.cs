using UnityEngine;
using UnityEngine.UI;

public class EnemyScript : MonoBehaviour
{
    public PlayerMovement player;
    private Animator _animator;
    public int _health = 20;
    readonly float _attackCoolDown = 5f;
    private float _lastAttackTime = 0f;
    public int damage = 7;
    readonly float _distanceToPlayer = 5f;
    public Slider SliderHealt;
    
    private void Start()
    {
        _animator = GetComponent<Animator>();
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerMovement>();
        EnemyResurrection();
    }

    private void Update()
    {
        PlayerDetection();
    }

    public void TakeDamage(int damage)
    {
        _health -= damage;
          SliderHealt.value= _health;
        Debug.Log("Enemy HP is " + _health);
        _animator.SetTrigger("GetHit");
        if (_health <= 0)
        {
            _animator.SetTrigger("DieTrigger");
            Destroy(gameObject, 5f);
            Destroy(SliderHealt);
        }
        
    }

    private void PlayerDetection()
    {
        Vector3 position = transform.position;
        if (Vector3.Distance(position, player.transform.position) <= _distanceToPlayer && _health > 0)
        {
            transform.LookAt(player.transform.position);
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
        if (gameObject == null)
        {
            
        }
    }
}
