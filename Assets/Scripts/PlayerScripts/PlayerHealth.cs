using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    // Player's current health
    public int playerHealth = 30;
    // Whether the player is currently defending with a shield
    private bool _isDefend;
    // Time before the player body disappears after death
    private float _deadPlayerBodyDisappearingTime = 5f;
    // Right mouse button index (for Input.GetMouseButton)
    private readonly int _mouseRB = 1;
    private Animator _animator;
    [SerializeField] Slider _HPslider;
    void Start()
    {
        _animator = GetComponent<Animator>();
    }
    void Update()
    {
        DefendAnimation();
    }
    
    public void TakeDamage(int damage)
    {
        // Ignore damage if defending
        if(_isDefend)
        {
            Debug.Log("Атака отбита щитом");
        }
        
        else
        {
            // Reduce health and update UI
            playerHealth -= damage;
            _HPslider.value = playerHealth;
            _animator.SetTrigger("GetHit");
            Debug.Log("Player Health is" + playerHealth);

            if (playerHealth <= 0)
            {
                _animator.SetTrigger("Death");
                Destroy(gameObject, _deadPlayerBodyDisappearingTime);
            }
        }
    }
    
    public void DefendAnimation()
    {
        // If right mouse button pressed start defending
        if(Input.GetMouseButtonDown(_mouseRB))
        {
            _animator.SetTrigger("Defend");
            _isDefend = true;
        }
        
        else if (Input.GetMouseButtonUp(_mouseRB))
        {
            _isDefend = false;
        }
    }

    public void TakeHealth(int health)
    {
        // Heal the player
        playerHealth += health;
        playerHealth = Mathf.Clamp(playerHealth, 0, 30);
        _HPslider.value = playerHealth;
        Debug.Log("Player Health is " + playerHealth);
    }
}
